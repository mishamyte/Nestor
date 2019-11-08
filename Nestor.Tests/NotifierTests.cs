using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Nestor.Core;
using Nestor.Core.Configuration;
using Nestor.Core.Dto;
using Nestor.Core.Providers;
using Nestor.Services;
using Nestor.Tests.Logger;
using NUnit.Framework;

namespace Nestor.Tests
{
    [TestFixture]
    public class NotifierTests
    {
        private readonly ILogger<NotifierService> _logger = new NUnitLogger<NotifierService>();

        [Test]
        public void NotifierShouldSkipIgnoredPokemons()
        {
            var triggeredCounter = 0;
            var silphNest = new NestInfoDto {Pokemon = new PokemonDto {Id = 16}};
            var settings = new Settings {Global = new Global {IgnoredPokemons = new List<int> {16}}};

            var botMock = new Mock<IBotProvider>();
            botMock.Setup(m => m.SendImage(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((uri, s) => { triggeredCounter++; });

            var notifier = new NotifierService(botMock.Object, _logger, settings);
            notifier.Notify(silphNest);

            Assert.AreEqual(0, triggeredCounter);
        }

        [Test]
        public void NotifierShouldSkipIgnoredNests()
        {
            var triggeredCounter = 0;
            var silphNest = new NestInfoDto {Id = 42};
            var settings = new Settings {Global = new Global {IgnoredNests = new List<int> {42}}};

            var botMock = new Mock<IBotProvider>();
            botMock.Setup(m => m.SendImage(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((uri, s) => { triggeredCounter++; });

            var notifier = new NotifierService(botMock.Object, _logger, settings);
            notifier.Notify(silphNest);

            Assert.AreEqual(0, triggeredCounter);
        }
    }
}