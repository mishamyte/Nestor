namespace Nestor.Interfaces.Settings
{
	public interface IParserSettings
	{
		int ParsingDelay { get; set; }
		double CenterLat { get; set; }
		double CenterLng { get; set; }
		double Lat1 { get; set; }
		double Lng1 { get; set; }
		double Lat2 { get; set; }
		double Lng2 { get; set; }
		int Zoom { get; set; }
	}
}
