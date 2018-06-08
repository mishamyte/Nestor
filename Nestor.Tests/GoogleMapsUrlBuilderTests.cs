using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nestor.Domain.Contracts;
using Nestor.Utils;
using NUnit.Framework;

namespace Nestor.Tests
{
	[TestFixture]
	public class GoogleMapsUrlBuilderTests
	{
		[Test]
		public void GMapsBuilderShouldBuildString()
		{
			var nest = new Nest
			{
				Id = 1,
				Lat = 50.5,
				Lng = 30.4,
				Pokemon = new Pokemon
				{
					Id = 25
				},
				PokemonId = 25
			};
			var iconsUrlFormat = "http://alakazam/pokeicons/{0}.png";
			var gmapsKey = "UUDDLRLRBA";

			var gmapsUrl = GoogleMapsUrlBuilder.GetUrlString(nest, gmapsKey, iconsUrlFormat);

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
			Assert.AreEqual(gmapsKey, urlParams["key"]);
		}

		[Test]
		public void GMapsBuilderShouldFormatId()
		{
			var nest = new Nest
			{
				Id = 1,
				Lat = 50.5,
				Lng = 30.4,
				Pokemon = new Pokemon
				{
					Id = 1
				},
				PokemonId = 1
			};
			var iconsUrlFormat = "http://alakazam/pokeicons/{0:D3}.png";
			var gmapsKey = "UUDDLRLRBA";

			var gmapsUrl = GoogleMapsUrlBuilder.GetUrlString(nest, gmapsKey, iconsUrlFormat);

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
			Assert.AreEqual(gmapsKey, urlParams["key"]);
		}

		private static IReadOnlyDictionary<string, string> ParseQueryString(Uri uri)
		{
			var regex = new Regex(@"[?|&]([\w\.]+)=([^?|^&]+)", RegexOptions.Compiled);
			var match = regex.Match(uri.PathAndQuery);
			var paramaters = new Dictionary<string, string>();
			while (match.Success)
			{
				paramaters.Add(match.Groups[1].Value, match.Groups[2].Value);
				match = match.NextMatch();
			}
			return paramaters;
		}

	}
}