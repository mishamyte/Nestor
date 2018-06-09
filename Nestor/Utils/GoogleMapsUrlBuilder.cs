﻿using System.Globalization;
using System.Text;
using Nestor.Contracts.Dtos;

namespace Nestor.Utils
{
	internal static class GoogleMapsUrlBuilder
	{
		internal static string GetUrlString(SilphNestDto nest, string gmapsKey, string iconsUrlFormat)
		{
			var sb = new StringBuilder();

			sb.Append("https://maps.googleapis.com/maps/api/staticmap?center=");
			sb.Append($"{nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}");
			sb.Append("&zoom=15");
			sb.Append("&size=600x400");
			sb.Append("&maptype=roadmap");
			sb.Append("&markers=icon:");
			sb.AppendFormat(iconsUrlFormat, nest.PokemonId);
			sb.Append($"%7C{nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&key={gmapsKey}");

			return sb.ToString();
		}
	}
}
