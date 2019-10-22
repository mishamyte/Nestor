using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Nestor.Core.Dto;
using Nestor.Core.Services;
using Nestor.Providers;
using NUnit.Framework;

namespace Nestor.Tests
{
    [TestFixture]
    public class NestProviderTests
    {
        private IConfigurationRoot _configuration;

        [OneTimeSetUp]
        public void SetUp()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("thesilphroadresponses.json")
                .Build();
        }

        [Test]
        public async Task ProviderShouldExtractMigrationNumberCorrectly()
        {
            var mock = new Mock<ITheSilphRoadService>();
            mock.Setup(m => m.GetNestHistory()).ReturnsAsync(_configuration["GetNestHistory"]);

            var parser = new TheSilphRoadNestProvider(mock.Object);

            var result = await parser.GetMigrationNumber();

            Assert.AreEqual(96, result);
        }

        [Test]
        public async Task ProviderShouldGetNestsCorrectly()
        {
            var expectedPokemonIds = new[]
            {
                170, 118, 39, 54, 77, 96, 19, 152, 66, 74, 163, 152, 215, 158, 223, 63, 124, 116, 21, 120, 56, 96, 81,
                90, 183, 23, 203, 100, 133, 133, 1, 104, 21, 13, 27, 23
            };
            var mock = new Mock<ITheSilphRoadService>();
            mock.Setup(m => m.GetLocalNests()).ReturnsAsync(_configuration["GetLocalNests"]);

            var parser = new TheSilphRoadNestProvider(mock.Object);

            var result = await parser.GetNests();
            var nestDtos = result as NestDto[] ?? result.ToArray();
            
            Assert.AreEqual(36, nestDtos.Length);
            Assert.AreEqual(expectedPokemonIds, nestDtos.Select(nest => nest.PokemonId));
        }
    }
}