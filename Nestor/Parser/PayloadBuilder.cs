using System.Globalization;
using System.Text;
using Nestor.Settings;

namespace Nestor.Parser
{
	internal class PayloadBuilder
	{
		internal string Build(IParserSettings settings)
		{
			var sb = new StringBuilder();

			sb.Append($"data[lat1]={settings.Lat1.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[lng1]={settings.Lng1.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[lat2]={settings.Lat2.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[lng2]={settings.Lng2.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[zoom]={settings.Zoom}");
			sb.Append("&data[mapFilterValues][mapTypes][]=1");
			sb.Append("&data[mapFilterValues][nestVerificationLevels][]=1");
			sb.Append("&data[mapFilterValues][nestTypes][]=-1");
			sb.Append($"&data[center_lat]={settings.CenterLat.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[center_lng]={settings.CenterLng.ToString(CultureInfo.InvariantCulture)}");

			return sb.ToString();
		}
	}
}
