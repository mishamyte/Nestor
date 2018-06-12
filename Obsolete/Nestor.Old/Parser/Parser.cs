﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nestor.Model;
using Nestor.Utils;
using Newtonsoft.Json.Linq;

namespace Nestor.Parser
{
	internal class Parser : IParser
	{
		private readonly INestProvider _provider;

		internal Parser(INestProvider provider)
		{
			_provider = provider;
		}

		public async Task<IList<Nest>> GetNests()
		{
			var responseString = await _provider.GetNestsJsonData();

			var success = JsonDeserializer.TryDeserializeObject(responseString, out JObject responseObject);

			if (success && responseObject?["localMarkers"] != null)
			{
				success = JsonDeserializer.TryDeserializeObject(responseObject["localMarkers"].ToString(), out Dictionary<string, Nest> result);

				if (success)
				{
					return result.Select(nest => nest.Value).ToList();
				}
			}
			return default(List<Nest>);
		}

		public void Dispose()
		{
			_provider.Dispose();
		}
	}
}