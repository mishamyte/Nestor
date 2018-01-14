using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Moq;
using Nestor.BusinessLogic;
using Nestor.DAL.Interfaces;
using Nestor.DTO;
using Nestor.Logging;
using Nestor.Model;
using Nestor.Parser;
using Nestor.Settings;
using NUnit.Framework;
using ILogger = Nestor.Logging.ILogger;
using NestType = Nestor.DTO.NestType;

namespace Nestor.Tests
{
	[TestFixture]
	public class NestWatcherTests
	{
		private const int MigrationNumber = 42;

		[Test]
		public void WatcherShouldFindNewNests()
		{
			var parserNests = GetParserNests();
			var dbNests = GetDbNests();

			var settingsMock = GetGlobalSettingsMock();

			var parserMock = new Mock<IParser>();
			parserMock.Setup(m => m.GetNests())
				.ReturnsAsync(parserNests);

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsRepository.Get(null))
				.Returns(dbNests);
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(new Pokemon
				{
					Id = 25,
					Name = "Pikachu"
				});

			var watcher = new NestsWatcher(settingsMock.Object, parserMock.Object, () => dbMock.Object);

			var task = watcher.GetMissingAndOutdatedNests();
			task.Wait();

			var resultingNests = task.Result;

			PrintNests(resultingNests);

			Assert.AreEqual(2, resultingNests.Count);
			Assert.AreEqual(2, resultingNests.Count(x => x.NestType == NestType.Missed));
		}

		[Test]
		public void WatcherShouldUpdateOutdatedNests()
		{
			var parserNests = GetParserNests();
			var dbNests = GetParserNests();

			foreach (var nest in dbNests.Where(n => n.Id > 1))
			{
				nest.LastMigration--;
			}

			var settingsMock = GetGlobalSettingsMock();

			var parserMock = new Mock<IParser>();
			parserMock.Setup(m => m.GetNests())
				.ReturnsAsync(parserNests);

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsRepository.Get(null))
				.Returns(dbNests);
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(new Pokemon
				{
					Id = 25,
					Name = "Pikachu"
				});

			var watcher = new NestsWatcher(settingsMock.Object, parserMock.Object, () => dbMock.Object);

			var task = watcher.GetMissingAndOutdatedNests();
			task.Wait();

			var resultingNests = task.Result;

			PrintNests(resultingNests);

			Assert.AreEqual(2, resultingNests.Count);
			Assert.AreEqual(2, resultingNests.Count(x => x.NestType == NestType.Outdated));
		}

		[Test]
		public void WatcherShouldProcessEmptyParserResponseCorrectly()
		{
			var dbNests = GetDbNests();
			var logString = string.Empty;

			var loggerMock = new Mock<ILogger>();
			loggerMock.Setup(m => m.LogDebug(It.IsAny<string>()))
				.Callback<string>(s =>
				{
					logString += s;
				});

			var settingsMock = GetGlobalSettingsMock();

			var parserMock = new Mock<IParser>();
			parserMock.Setup(m => m.GetNests())
				.ReturnsAsync((IList<Nest>)null);

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsRepository.Get(null))
				.Returns(dbNests);
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(new Pokemon
				{
					Id = 25,
					Name = "Pikachu"
				});

			Logger.RegisterLogger(loggerMock.Object);
			var watcher = new NestsWatcher(settingsMock.Object, parserMock.Object, () => dbMock.Object);

			var task = watcher.GetMissingAndOutdatedNests();
			task.Wait();

			var resultingNests = task.Result;

			Assert.IsTrue(resultingNests.IsNullOrEmpty());
			Assert.IsTrue(logString.Contains("Empty parser response"));
		}

		[Test]
		public void WatcherShouldProcessNestTypeMissed()
		{
			var nestWasAdded = false;

			var nestDto = new NestDto
			{
				Nest = new Nest
				{
					Id = 42,
					Pokemon = new Pokemon
					{
						Name = "Pikachu"
					}
				},
				NestType = NestType.Missed
			};

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsRepository.Insert(It.IsAny<Nest>()))
				.Callback<Nest>(nest =>
				{
					nestWasAdded = nest.Id == nestDto.Nest.Id;
				});

			var watcher = new NestsWatcher(null, null, () => dbMock.Object);

			watcher.ProcessNest(nestDto);

			Assert.IsTrue(nestWasAdded);
		}

		[Test]
		public void WatcherShouldProcessNestTypeOutdated()
		{
			var nestWasUpdated = false;

			var nestDto = new NestDto
			{
				Nest = new Nest
				{
					Id = 42,
					Pokemon = new Pokemon
					{
						Name = "Pikachu"
					}
				},
				NestType = NestType.Outdated
			};

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsRepository.Update(It.IsAny<Nest>()))
				.Callback<Nest>(nest =>
				{
					nestWasUpdated = nest.Id == nestDto.Nest.Id;
				});

			var watcher = new NestsWatcher(null, null, () => dbMock.Object);

			watcher.ProcessNest(nestDto);

			Assert.IsTrue(nestWasUpdated);
		}

		[Test]
		public void WatcherShouldThrowExceptionOnUnknownNestType()
		{
			var nestDto = new NestDto
			{
				NestType = (NestType) 999
			};

			var watcher = new NestsWatcher(null, null, null);

			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => watcher.ProcessNest(nestDto));
			Assert.AreEqual($"Unexpected nest type {nestDto.NestType}", exception.ParamName);
		}

		private static List<Nest> GetDbNests()
		{
			var dbNests = new List<Nest>
			{
				new Nest
				{
					Id = 1,
					LastMigration = MigrationNumber
				}
			};

			return dbNests;
		}

		private static List<Nest> GetParserNests()
		{
			var parserNests = new List<Nest>
			{
				new Nest
				{
					Id = 1,
					LastMigration = MigrationNumber
				},
				new Nest
				{
					Id = 2,
					LastMigration = MigrationNumber
				},
				new Nest
				{
					Id = 3,
					LastMigration = MigrationNumber
				}
			};

			return parserNests;
		}

		private static Mock<IGlobalSettings> GetGlobalSettingsMock()
		{
			var mock = new Mock<IGlobalSettings>();
			mock.Setup(m => m.MigrationNumber)
				.Returns(MigrationNumber);

			return mock;
		}

		private static void PrintNests(IEnumerable<NestDto> nests)
		{
			foreach (var nest in nests)
			{
				Console.WriteLine($"Id: {nest.Nest.Id}\tNest Type: {nest.NestType.ToString()}");
			}
		}
	}
}
