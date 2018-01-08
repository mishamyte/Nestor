using System;
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

			var settingsMock = new Mock<ISettings>();
			settingsMock.Setup(m => m.GlobalSettings.MessageType)
				.Returns(MessageType.Image);

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

			var settingsMock = new Mock<ISettings>();
			settingsMock.Setup(m => m.GlobalSettings.MessageType)
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

			var settingsMock = new Mock<ISettings>();
			settingsMock.Setup(m => m.GlobalSettings.MessageType)
				.Returns((MessageType) unknownMessageType);

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

			var settingsMock = new Mock<ISettings>();
			settingsMock.Setup(m => m.GlobalSettings.MessageType)
				.Returns(MessageType.Image);
			settingsMock.Setup(m => m.GlobalSettings.MigrationNumber)
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

			var settingsMock = new Mock<ISettings>();
			settingsMock.Setup(m => m.GlobalSettings.MessageType)
				.Returns(MessageType.Image);
			settingsMock.Setup(m => m.GlobalSettings.MigrationNumber)
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
	}
}
