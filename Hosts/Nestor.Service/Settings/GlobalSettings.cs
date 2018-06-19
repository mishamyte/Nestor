using System.Collections.Generic;
using Nestor.Contracts.Settings;

namespace Nestor.Service.Settings
{
	public class GlobalSettings : IGlobalSettings
	{
		public string GoogleMapsKey { get; set; }

		public string IconsUrlFormat { get; set; }

		public List<int> IgnoredNests { get; set; }

		public List<int> IgnoredPokemons { get; set; }

		public MessageType MessageType { get; set; }
	}
}
