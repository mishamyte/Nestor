using System;
using System.Collections.Generic;
using Moq;
using Nestor.Contracts;
using Nestor.Contracts.Dtos;
using Nestor.Contracts.Settings;
using Nestor.Domain.Contracts;
using NUnit.Framework;
using Serilog;
using NestType = Nestor.Domain.Contracts.NestType;

namespace Nestor.Tests
{
	[TestFixture]
	public class NotifierTests
	{
		[Test]
		public void NotifierShouldProcessMessageTypeImage()
		{
			var imageWasSent = false;

			var silphNest = GetTestNestDto();

			var nest = new Nest
			{
				NestType = NestType.Default,
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var settingsMock = CreateGlobalSettingsMock();

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<string>(), It.IsAny<string>()))
				.Callback<string, string>((uri, s) =>
				{
					imageWasSent = true;
				});

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsInfoRepository.GetById(It.IsAny<object>()))
				.Returns(default(NestInfo));
			dbMock.Setup(m => m.NestsRepository.GetById(It.IsAny<object>()))
				.Returns(nest);

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object, Log.Logger);
			notifier.Notify(silphNest);

			Assert.IsTrue(imageWasSent);
		}

		[Test]
		public void NotifierShouldProcessMessageTypeLocation()
		{
			var locationWasSent = false;

			var silphNest = GetTestNestDto();

			var nest = new Nest
			{
				NestType = NestType.Default,
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.MessageType)
				.Returns(MessageType.Location);

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendLocation(It.IsAny<float>(), It.IsAny<float>()))
				.Callback<float, float>((lat, lng) =>
				{
					locationWasSent = true;
				});

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsInfoRepository.GetById(It.IsAny<object>()))
				.Returns(default(NestInfo));
			dbMock.Setup(m => m.NestsRepository.GetById(It.IsAny<object>()))
				.Returns(nest);

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object, Log.Logger);
			notifier.Notify(silphNest);

			Assert.IsTrue(locationWasSent);
		}

		[Test]
		public void NotifierShouldThrowExceptionOnUnknownMessageType()
		{
			const int unknownMessageType = 999;

			var silphNest = GetTestNestDto();

			var nest = new Nest
			{
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.MessageType)
				.Returns((MessageType)unknownMessageType);

			var botMock = new Mock<IBotProvider>();

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsInfoRepository.GetById(It.IsAny<object>()))
				.Returns(default(NestInfo));

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object, Log.Logger);

			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => notifier.Notify(silphNest));
			Assert.AreEqual($"Unknown message type {unknownMessageType}", exception.ParamName);
		}

		[Test]
		public void NotifierShouldProcessNestInsert()
		{
			var captionString = string.Empty;

			var silphNest = GetTestNestDto();
			silphNest.NestType = Contracts.Dtos.NestType.Missed;

			var nest = new Nest
			{
				Lat = 50.42,
				Lng = 42.50,
				NestType = NestType.Default,
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.MigrationNumber)
				.Returns(42);

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<string>(), It.IsAny<string>()))
				.Callback<string, string>((uri, s) =>
				{
					captionString = s;
				});

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsInfoRepository.GetById(It.IsAny<object>()))
				.Returns(new NestInfo
				{
					HashtagName = "TestPikachuNest",
					Id = 42,
					Name = "Test Pikachu Nest"
				});
			dbMock.Setup(m => m.NestsRepository.GetById(It.IsAny<object>()))
				.Returns(nest);

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object, Log.Logger);
			notifier.Notify(silphNest);

			Log.Information(captionString);

			Assert.IsTrue(!string.IsNullOrEmpty(captionString));
			Assert.IsFalse(captionString.Contains("NEST INFO UPDATED"));
		}

		[Test]
		public void NotifierShouldProcessNestUpdate()
		{
			var captionString = string.Empty;

			var silphNest = GetTestNestDto();
			silphNest.NestType = Contracts.Dtos.NestType.Outdated;

			var nest = new Nest
			{
				Lat = 50.42,
				Lng = 42.50,
				NestType = NestType.Default,
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.MigrationNumber)
				.Returns(42);

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<string>(), It.IsAny<string>()))
				.Callback<string, string>((uri, s) =>
				{
					captionString = s;
				});

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsInfoRepository.GetById(It.IsAny<object>()))
				.Returns(new NestInfo
				{
					HashtagName = "TestPikachuNest",
					Id = 42,
					Name = "Test Pikachu Nest"
				});
			dbMock.Setup(m => m.NestsRepository.GetById(It.IsAny<object>()))
				.Returns(nest);

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object, Log.Logger);
			notifier.Notify(silphNest);

			Log.Information(captionString);

			Assert.IsTrue(!string.IsNullOrEmpty(captionString));
			Assert.IsTrue(captionString.Contains("NEST INFO UPDATED"));
		}

		[Test]
		public void NotifierShouldSkipIgnoredPokemons()
		{
			var triggeredCounter = 0;

			var silphNest = GetTestNestDto(16);

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.IgnoredPokemons)
				.Returns(new List<int> { 16 });

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<string>(), It.IsAny<string>()))
				.Callback<string, string>((uri, s) =>
				{
					triggeredCounter++;
				});

			var notifier = new Notifier(settingsMock.Object, botMock.Object, null, Log.Logger);
			notifier.Notify(silphNest);

			Assert.AreEqual(0, triggeredCounter);
		}

		[Test]
		public void NotifierShouldSkipIgnoredNests()
		{
			var triggeredCounter = 0;

			var silphNest = GetTestNestDto(16);
			silphNest.Nest.Id = 42;

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.IgnoredNests)
				.Returns(new List<int> { 42 });

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<string>(), It.IsAny<string>()))
				.Callback<string, string>((uri, s) =>
				{
					triggeredCounter++;
				});

			var notifier = new Notifier(settingsMock.Object, botMock.Object, null, Log.Logger);
			notifier.Notify(silphNest);

			Assert.AreEqual(0, triggeredCounter);
		}

		private static Mock<IGlobalSettings> CreateGlobalSettingsMock()
		{
			var mock = new Mock<IGlobalSettings>();
			mock.Setup(m => m.MessageType)
				.Returns(MessageType.Image);
			mock.Setup(m => m.IconsUrlFormat)
				.Returns(string.Empty);
			mock.Setup(m => m.IgnoredPokemons)
				.Returns(new List<int>());
			mock.Setup(m => m.IgnoredNests)
				.Returns(new List<int>());

			return mock;
		}

		private static NestDto GetTestNestDto(int pokemonId = 25)
		{
			var silphNest = new NestDto
			{
				Nest = new Nest
				{
					PokemonId = pokemonId
				}
			};

			return silphNest;
		}
	}
}