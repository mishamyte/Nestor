using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Nestor.Interfaces;

namespace Nestor.Parser
{
	public class TheSilphRoadParser : Parser
	{
		// It's recommended to instantiate one HttpClient per app
		private static readonly HttpClient Client = new HttpClient();

		public TheSilphRoadParser(ISettings settings) : base(settings)
		{
		}

		public override async Task<string> GetNests()
		{
			var payload = new Dictionary<string, string>
			{
				{ "data[lat1]", Settings.Lat1.ToString(CultureInfo.InvariantCulture) },
				{ "data[lng1]", Settings.Lng1.ToString(CultureInfo.InvariantCulture) },
				{ "data[lat2]", Settings.Lat2.ToString(CultureInfo.InvariantCulture) },
				{ "data[lng2]", Settings.Lng2.ToString(CultureInfo.InvariantCulture) },
				{ "data[center_lat]", Settings.CenterLat.ToString(CultureInfo.InvariantCulture) },
				{ "data[center_lng]", Settings.CenterLng.ToString(CultureInfo.InvariantCulture) },
				{ "data[mapFilterValues][mapTypes][]", "1" },
				{ "data[mapFilterValues][nestVerificationLevels][]", "1" },
				{ "data[mapFilterValues][nestTypes][]", "0" },
				{ "data[mapFilterValues][nestTypes][]", "1" },
				{ "data[mapFilterValues][nestTypes][]", "2" },
				{ "data[mapFilterValues][nestTypes][]", "3" }
			};

			var content = new FormUrlEncodedContent(payload);

			var response = await Client.PostAsync("https://thesilphroad.com/atlas/getLocalNests.json", content);

			return await response.Content.ReadAsStringAsync();		
		}

		public override void Dispose()
		{
			Client.Dispose();
		}
	}
}
