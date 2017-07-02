using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nestor.Interfaces;
using Nestor.Model;
using Nestor.Utils;
using Newtonsoft.Json.Linq;

namespace Nestor.Parser
{
	public class Parser : IParser, IDisposable
	{
		// It's recommended to instantiate one HttpClient per app
		private static readonly HttpClient Client = new HttpClient();
		private readonly ISettings _settings;

		public Parser(ISettings settings)
		{
			_settings = settings;
		}

		public async Task<IList<Nest>> GetNests()
		{
			var responseString = await GetSilphroadResponse();

			JObject responseObject;

			var success = JsonDeserializer.TryDeserializeObject(responseString, out responseObject);

			if (success && responseObject?["localMarkers"] != null)
			{
				Dictionary<string, Nest> result;
				success = JsonDeserializer.TryDeserializeObject(responseObject["localMarkers"].ToString(), out result);

				if (success)
				{
					return result.Select(nest => nest.Value).ToList();
				}
			}
			return default(List<Nest>);
		}

		private async Task<string> GetSilphroadResponse()
		{
			var pb = new PayloadBuilder();

			var payload = pb.Build(_settings);

			var content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");

			var response = await Client.PostAsync("https://thesilphroad.com/atlas/getLocalNests.json", content);

			return await response.Content.ReadAsStringAsync();		
		}

		public void Dispose()
		{
			Client.Dispose();
		}
	}
}
