using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nestor.Core;
using Nestor.Core.Configuration;
using Nestor.Core.Services;

namespace Nestor.Services
{
    public class TheSilphRoadService : ITheSilphRoadService
    {
        private readonly HttpClient _client;
        private readonly Parser _parserSettings;

        public TheSilphRoadService(HttpClient client, Settings settings)
        {
            client.BaseAddress = new Uri("https://thesilphroad.com/");

            _client = client;
            _parserSettings = settings.Parser;
        }

        public async Task<string> GetLocalNests()
        {
            var content = GetRequestContent(GetLocalNestsRequest());
            var response = await _client.PostAsync("atlas/getLocalNests.json", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetNestHistory()
        {
            var content = GetRequestContent("data[nest_id]=1");
            var response = await _client.PostAsync("nests/getNestHistory.json", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private string GetLocalNestsRequest()
        {
            var sb = new StringBuilder();

            sb.Append($"data[lat1]={_parserSettings.Lat1.ToString(CultureInfo.InvariantCulture)}");
            sb.Append($"&data[lng1]={_parserSettings.Lng1.ToString(CultureInfo.InvariantCulture)}");
            sb.Append($"&data[lat2]={_parserSettings.Lat2.ToString(CultureInfo.InvariantCulture)}");
            sb.Append($"&data[lng2]={_parserSettings.Lng2.ToString(CultureInfo.InvariantCulture)}");
            sb.Append($"&data[zoom]={_parserSettings.Zoom}");
            sb.Append("&data[mapFilterValues][mapTypes][]=1");
            sb.Append("&data[mapFilterValues][nestVerificationLevels][]=1");
            sb.Append("&data[mapFilterValues][nestTypes][]=-1");
            sb.Append($"&data[center_lat]={_parserSettings.CenterLat.ToString(CultureInfo.InvariantCulture)}");
            sb.Append($"&data[center_lng]={_parserSettings.CenterLng.ToString(CultureInfo.InvariantCulture)}");

            return sb.ToString();
        }

        private static StringContent GetRequestContent(string payload)
        {
            return new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");
        }
    }
}