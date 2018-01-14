using System;
using System.Collections.Generic;
using Moq;
using Nestor.BusinessLogic;
using Nestor.DAL.Interfaces;
using Nestor.Model;
using Nestor.Settings;
using Nestor.TelegramBot;
using NUnit.Framework;

namespace Nestor.Tests
{
	[TestFixture]
	public class NotifierTests
	{
		[Test]
		public void NotifierShouldProcessMessageTypeImage()
		{
			var imageWasSent = false;

			var settingsMock = CreateGlobalSettingsMock();

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<Uri>(), It.IsAny<string>()))
				.Callback<Uri, string>((uri, s) =>
				{
					imageWasSent = true;
				});

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsInfoRepository.GetById(It.IsAny<object>()))
				.Returns(default(NestInfo));

			var nest = new Nest
			{
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object);
			notifier.Notify(nest);

			Assert.IsTrue(imageWasSent);
		}

		[Test]
		public void NotifierShouldProcessMessageTypeLocation()
		{
			var locationWasSent = false;

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

			var nest = new Nest
			{
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object);
			notifier.Notify(nest);

			Assert.IsTrue(locationWasSent);
		}

		[Test]
		public void NotifierShouldThrowExceptionOnUnknownMessageType()
		{
			const int unknownMessageType = 999;

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.MessageType)
				.Returns((MessageType)unknownMessageType);

			var botMock = new Mock<IBotProvider>();

			var dbMock = new Mock<IDatabaseProvider>();
			dbMock.Setup(m => m.NestsInfoRepository.GetById(It.IsAny<object>()))
				.Returns(default(NestInfo));

			var nest = new Nest
			{
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object);

			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => notifier.Notify(nest));
			Assert.AreEqual($"Unknown message type {unknownMessageType}", exception.ParamName);
		}

		[Test]
		public void NotifierShouldProcessNestInsert()
		{
			var captionString = string.Empty;

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.MigrationNumber)
				.Returns(42);

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<Uri>(), It.IsAny<string>()))
				.Callback<Uri, string>((uri, s) =>
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

			var nest = new Nest
			{
				Lat = 50.42,
				Lng = 42.50,
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object);
			notifier.Notify(nest);

			Console.WriteLine(captionString);

			Assert.IsTrue(!string.IsNullOrEmpty(captionString));
			Assert.IsFalse(captionString.Contains("NEST INFO UPDATED"));
		}

		[Test]
		public void NotifierShouldProcessNestUpdate()
		{
			var captionString = string.Empty;

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.MigrationNumber)
				.Returns(42);

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<Uri>(), It.IsAny<string>()))
				.Callback<Uri, string>((uri, s) =>
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

			var nest = new Nest
			{
				Lat = 50.42,
				Lng = 42.50,
				Pokemon = new Pokemon
				{
					Name = "Pikachu"
				}
			};

			var notifier = new Notifier(settingsMock.Object, botMock.Object, () => dbMock.Object);
			notifier.Notify(nest, true);

			Console.WriteLine(captionString);

			Assert.IsTrue(!string.IsNullOrEmpty(captionString));
			Assert.IsTrue(captionString.Contains("NEST INFO UPDATED"));
		}

		[Test]
		public void NotifierShouldSkipIgnoredPokemons()
		{
			var triggeredCounter = 0;

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.IgnoredPokemons)
				.Returns(new List<int> { 16 });

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<Uri>(), It.IsAny<string>()))
				.Callback<Uri, string>((uri, s) =>
				{
					triggeredCounter++;
				});

			var nest = new Nest
			{
				PokemonId = 16
			};

			var notifier = new Notifier(settingsMock.Object, botMock.Object, null);
			notifier.Notify(nest);

			Assert.AreEqual(0, triggeredCounter);
		}

		[Test]
		public void NotifierShouldSkipIgnoredNests()
		{
			var triggeredCounter = 0;

			var settingsMock = CreateGlobalSettingsMock();
			settingsMock.Setup(m => m.IgnoredNests)
				.Returns(new List<int> { 42 });

			var botMock = new Mock<IBotProvider>();
			botMock.Setup(m => m.SendImage(It.IsAny<Uri>(), It.IsAny<string>()))
				.Callback<Uri, string>((uri, s) =>
				{
					triggeredCounter++;
				});

			var nest = new Nest
			{
				Id = 42,
				PokemonId = 16
			};

			var notifier = new Notifier(settingsMock.Object, botMock.Object, null);
			notifier.Notify(nest);

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
	}
}
