using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nestor.Interfaces;
using Nestor.Model;

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

		public Task<IList<Nest>> GetNests()
		{
			throw new NotImplementedException();
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
