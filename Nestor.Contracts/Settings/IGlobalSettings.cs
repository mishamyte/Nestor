using System.Collections.Generic;

namespace Nestor.Contracts.Settings
{
	public interface IGlobalSettings
	{
		int MigrationNumber { get; set; }

		MessageType MessageType { get; set; }

		string GoogleMapsKey { get; set; }

		string IconsUrlFormat { get; set; }

		List<int> IgnoredPokemons { get; set; }

		List<int> IgnoredNests { get; set; }
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
