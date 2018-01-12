﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nestor.Settings
{
	public interface IGlobalSettings
	{
		int MigrationNumber { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		MessageType MessageType { get; set; }

		string GoogleMapsKey { get; set; }
	}

	public enum MessageType
	{
		// One message with image, text in the description
		// Link to the google maps is in the text
		Image,
		// Two messages, text and location
		// No link to the google maps
		Location
	}
}