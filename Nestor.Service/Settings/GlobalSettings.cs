using Nestor.Settings;

namespace Nestor.Service.Settings
{
	public class GlobalSettings : IGlobalSettings
	{
		public string GoogleMapsKey { get; set; }

		public MessageType MessageType { get; set; }

		public int MigrationNumber { get; set; }

		public string IconsUrlFormat { get; set; }
	}
}
