using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nestor.Interfaces;

namespace Nestor.Parser
{
	public class TheSilphRoadProvider : INestProvider, IDisposable
	{
		// It's recommended to instantiate one HttpClient per app
		private static readonly HttpClient Client = new HttpClient();
		private readonly ISettings _settings;

		public TheSilphRoadProvider(ISettings settings)
		{
			_settings = settings;
		}

		public async Task<string> GetNestsJsonData()
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
