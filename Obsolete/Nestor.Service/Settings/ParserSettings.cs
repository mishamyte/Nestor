using Nestor.Settings;

namespace Nestor.Service.Settings
{
	public class ParserSettings : IParserSettings
	{
		public double CenterLat { get; set; }

		public double CenterLng { get; set; }

		public double Lat1 { get; set; }

		public double Lat2 { get; set; }

		public double Lng1 { get; set; }

		public double Lng2 { get; set; }

		public int ParsingDelay { get; set; }

		public int Zoom { get; set; }
	}
}
