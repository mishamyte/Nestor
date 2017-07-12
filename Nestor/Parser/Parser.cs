using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nestor.Interfaces;
using Nestor.Model;
using Nestor.Utils;
using Newtonsoft.Json.Linq;

namespace Nestor.Parser
{
	public class Parser : IParser
	{
		private readonly INestProvider _provider;

		public Parser(INestProvider provider)
		{
			_provider = provider;
		}

		public async Task<IList<Nest>> GetNests()
		{
			var responseString = await _provider.GetNestsJsonData();

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
	}
}
