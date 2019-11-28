using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nestor.Core.Dto;
using Nestor.Utils;
using NUnit.Framework;

namespace Nestor.Tests
{
    [TestFixture]
    public class GoogleMapsUrlBuilderTests
    {
        private const string GMapsKey = "UUDDLRLRBA";

        [Test]
        public void GMapsBuilderShouldBuildString()
        {
            const string iconsUrlFormat = "http://alakazam/pokeicons/{0}.png";

            var nest = new NestInfoDto
            {
                Lat = 50.5,
                Lng = 30.4,
                Pokemon = new PokemonDto
                {
                    Id = 25
                }
            };

            var gmapsUrl = GoogleMapsUrlBuilder.GetUrlString(nest, GMapsKey, iconsUrlFormat);

            var url = new Uri(gmapsUrl);
            Assert.AreEqual("maps.googleapis.com", url.Host);
            Assert.AreEqual("/maps/api/staticmap", url.AbsolutePath);

            var urlParams = ParseQueryString(url);
            Assert.AreEqual(6, urlParams.Count);
            Assert.AreEqual("50.5,30.4", urlParams["center"]);
            Assert.AreEqual("15", urlParams["zoom"]);
            Assert.AreEqual("600x400", urlParams["size"]);
            Assert.AreEqual("roadmap", urlParams["maptype"]);
            Assert.AreEqual("icon:http://alakazam/pokeicons/25.png%7C50.5,30.4", urlParams["markers"]);
            Assert.AreEqual(GMapsKey, urlParams["key"]);
        }

        [Test]
        public void GMapsBuilderShouldFormatId()
        {
            const string iconsUrlFormat = "http://alakazam/pokeicons/{0:D3}.png";

            var nest = new NestInfoDto
            {
                Lat = 50.5,
                Lng = 30.4,
                Pokemon = new PokemonDto
                {
                    Id = 1
                }
            };

            var gmapsUrl = GoogleMapsUrlBuilder.GetUrlString(nest, GMapsKey, iconsUrlFormat);

            var url = new Uri(gmapsUrl);
            Assert.AreEqual("maps.googleapis.com", url.Host);
            Assert.AreEqual("/maps/api/staticmap", url.AbsolutePath);

            var urlParams = ParseQueryString(url);
            Assert.AreEqual(6, urlParams.Count);
            Assert.AreEqual("50.5,30.4", urlParams["center"]);
            Assert.AreEqual("15", urlParams["zoom"]);
            Assert.AreEqual("600x400", urlParams["size"]);
            Assert.AreEqual("roadmap", urlParams["maptype"]);
            Assert.AreEqual("icon:http://alakazam/pokeicons/001.png%7C50.5,30.4", urlParams["markers"]);
            Assert.AreEqual(GMapsKey, urlParams["key"]);
        }

        private static IReadOnlyDictionary<string, string> ParseQueryString(Uri uri)
        {
            var regex = new Regex(@"[?|&]([\w\.]+)=([^?|^&]+)", RegexOptions.Compiled);
            var match = regex.Match(uri.PathAndQuery);
            var parameters = new Dictionary<string, string>();
            while (match.Success)
            {
                parameters.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }

            return parameters;
        }
    }
}