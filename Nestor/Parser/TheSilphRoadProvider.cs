using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nestor.Contracts;
using Nestor.Contracts.Settings;

namespace Nestor
{
	internal class TheSilphRoadProvider : INestProvider
	{
		// It's recommended to instantiate one HttpClient per app
		private readonly HttpClient _client;
		private readonly Policies _policies;
		private readonly IParserSettings _settings;

		public TheSilphRoadProvider(HttpClient client, Policies policies, IParserSettings settings)
		{
			_client = client;
			_policies = policies;
			_settings = settings;
		}

		public async Task<string> GetNestHistoryJsonData()
		{
			var payload = GetNestHistoryRequest();

			var content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");

			var response = await _policies.ExternalHttpProviderPolicy.ExecuteAsync(() =>
				_client.PostAsync("https://thesilphroad.com/nests/getNestHistory.json", content));

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> GetLocalNestsJsonData()
		{
			var payload = GetLocalNestsRequest();

			var content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");

			var response = await _policies.ExternalHttpProviderPolicy.ExecuteAsync(() =>
				_client.PostAsync("https://thesilphroad.com/atlas/getLocalNests.json", content));

			return await response.Content.ReadAsStringAsync();
		}

		public void Dispose()
		{
			_client.Dispose();
		}

		private string GetLocalNestsRequest()
		{
			var sb = new StringBuilder();

			sb.Append($"data[lat1]={_settings.Lat1.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[lng1]={_settings.Lng1.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[lat2]={_settings.Lat2.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[lng2]={_settings.Lng2.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[zoom]={_settings.Zoom}");
			sb.Append("&data[mapFilterValues][mapTypes][]=1");
			sb.Append("&data[mapFilterValues][nestVerificationLevels][]=1");
			sb.Append("&data[mapFilterValues][nestTypes][]=-1");
			sb.Append($"&data[center_lat]={_settings.CenterLat.ToString(CultureInfo.InvariantCulture)}");
			sb.Append($"&data[center_lng]={_settings.CenterLng.ToString(CultureInfo.InvariantCulture)}");

			return sb.ToString();
		}

		private static string GetNestHistoryRequest()
		{
			return "data[nest_id]=1";
		}
	}
}