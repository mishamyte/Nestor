﻿using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nestor.Utils;
using Nestor.Model;
using System.Globalization;

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
					Id = 25,
					Name = "Pikachu"
				},
				PokemonId = 25
			};

			var gmapsUrl = GoogleMapsUrlBuilder.GetUrlString(nest, "RRBBL");

			var url = new Uri(gmapsUrl);
			Assert.AreEqual("maps.googleapis.com", url.Host);
			Assert.AreEqual("/maps/api/staticmap", url.AbsolutePath);

			var urlParams = ParseQueryString(url);
			Assert.AreEqual(6, urlParams.Count);
			Assert.AreEqual($"{nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}", urlParams["center"]);
			Assert.AreEqual("15", urlParams["zoom"]);
			Assert.AreEqual("600x400", urlParams["size"]);
			Assert.AreEqual("roadmap", urlParams["maptype"]);
			Assert.AreEqual($"icon:http://directive901.com/pokeicons/{nest.PokemonId}.png%7C{urlParams["center"]}", urlParams["markers"]);
			Assert.AreEqual("RRBBL", urlParams["key"]);
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