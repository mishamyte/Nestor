using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Castle.Core.Internal;
using Moq;
using Nestor.Contracts;
using Nestor.Contracts.Dtos;
using Nestor.Contracts.Settings;
using Nestor.Domain.Contracts;
using NUnit.Framework;
using Serilog;
using NestType = Nestor.Contracts.Dtos.NestType;

namespace Nestor.Tests
{
	[TestFixture]
	public class NestWatcherTests
	{
		private const int MigrationNumber = 42;

		[SetUp]
		public void SetUp()
		{
			AutoMapperConfiguration.Configure();
		}

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
			dbMock.Setup(m => m.NestsRepository.Get(It.IsAny<Expression<Func<Nest, bool>>>()))
				.Returns((Expression<Func<Nest, bool>> predicate) => dbNests.Where(predicate.Compile()));

			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(new Pokemon
				{
					Id = 25,
					Name = "Pikachu"
				});

			var watcher = new NestsWatcher(settingsMock.Object, parserMock.Object, () => dbMock.Object, Log.Logger);

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
			var dbNests = GetPartiallyOutdatedDbNests(parserNests);

			var settingsMock = GetGlobalSettingsMock();

			var parserMock = new Mock<IParser>();
			parserMock.Setup(m => m.GetNests())
				.ReturnsAsync(parserNests);

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsRepository.Get(It.IsAny<Expression<Func<Nest, bool>>>()))
				.Returns((Expression<Func<Nest, bool>> predicate) => dbNests.Where(predicate.Compile()));
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(new Pokemon
				{
					Id = 25,
					Name = "Pikachu"
				});

			var watcher = new NestsWatcher(settingsMock.Object, parserMock.Object, () => dbMock.Object, Log.Logger);

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
			loggerMock.Setup(m => m.Warning(It.IsAny<string>()))
				.Callback<string>(s =>
				{
					logString += s;
				});

			var settingsMock = GetGlobalSettingsMock();

			var parserMock = new Mock<IParser>();
			parserMock.Setup(m => m.GetNests())
				.ReturnsAsync((List<SilphNestDto>) null);

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsRepository.Get(null))
				.Returns(dbNests);
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(new Pokemon
				{
					Id = 25,
					Name = "Pikachu"
				});

			var watcher = new NestsWatcher(settingsMock.Object, parserMock.Object, () => dbMock.Object, loggerMock.Object);

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

			var settingsMock = GetGlobalSettingsMock();

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
			dbMock.Setup(m => m.NestsUpdatesRepository.Insert(It.IsAny<NestUpdate>()));
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(nestDto.Nest.Pokemon);

			var watcher = new NestsWatcher(settingsMock.Object, null, () => dbMock.Object, Log.Logger);

			watcher.ProcessNest(nestDto);

			Assert.IsTrue(nestWasAdded);
		}

		[Test]
		public void WatcherShouldProcessNestTypeOutdated()
		{
			var nestWasUpdated = false;

			var settingsMock = GetGlobalSettingsMock();

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
			dbMock.Setup(m => m.NestsUpdatesRepository.Insert(It.IsAny<NestUpdate>()));
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(nestDto.Nest.Pokemon);

			var watcher = new NestsWatcher(settingsMock.Object, null, () => dbMock.Object, Log.Logger);

			watcher.ProcessNest(nestDto);

			Assert.IsTrue(nestWasUpdated);
		}

		[Test]
		public void WatcherShouldThrowExceptionOnUnknownNestType()
		{
			var settingsMock = GetGlobalSettingsMock();

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
				NestType = (NestType)999
			};

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsUpdatesRepository.Insert(It.IsAny<NestUpdate>()));

			var watcher = new NestsWatcher(settingsMock.Object, null, () => dbMock.Object, Log.Logger);

			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => watcher.ProcessNest(nestDto));
			Assert.AreEqual($"Unexpected nest type {nestDto.NestType}", exception.ParamName);
		}

		[Test]
		public void WatcherShouldRecordHistoryCorrectly()
		{
			NestUpdate insertedDto = null;

			var settingsMock = GetGlobalSettingsMock();

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsUpdatesRepository.Insert(It.IsAny<NestUpdate>()))
				.Callback<NestUpdate>(update =>
				{
					insertedDto = update;
				});
			dbMock.Setup(m => m.PokemonsRepository.GetById(It.IsAny<object>()))
				.Returns(new Pokemon { Name = "Pikachu" });

			var nestDto = new NestDto
			{
				Nest = new Nest
				{ 
				Id = 42,
				PokemonId = 25
				}
			};

			var watcher = new NestsWatcher(settingsMock.Object, null, () => dbMock.Object, Log.Logger);
			watcher.RecordNestUpdateToHistory(nestDto);

			Assert.IsNotNull(insertedDto);
			Assert.AreEqual(nestDto.Nest.Id, insertedDto.NestId);
			Assert.AreEqual(nestDto.Nest.PokemonId, insertedDto.PokemonId);
			Assert.AreEqual(MigrationNumber, insertedDto.MigrationNumber);
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

		private static List<Nest> GetPartiallyOutdatedDbNests(IEnumerable<SilphNestDto> silphNests)
		{
			return silphNests.Select(silphNest => new Nest
				{
					Id = silphNest.Id,
					LastMigration = silphNest.Id > 1 ? MigrationNumber -1 : MigrationNumber
				})
				.ToList();
		}

		private static List<SilphNestDto> GetParserNests()
		{
			var parserNests = new List<SilphNestDto>
			{
				new SilphNestDto
				{
					Id = 1
				},
				new SilphNestDto
				{
					Id = 2
				},
				new SilphNestDto
				{
					Id = 3
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
				Log.Information($"Id: {nest.Nest.Id}\tNest Type: {nest.NestType.ToString()}");
			}
		}
	}
}