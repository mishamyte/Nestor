using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nestor.Contracts;
using Nestor.Contracts.Dtos;
using Nestor.Utils;
using Newtonsoft.Json.Linq;

namespace Nestor
{
	internal class Parser : IParser
	{
		private readonly INestProvider _provider;

		public Parser(INestProvider provider)
		{
			_provider = provider;
		}

		public void Dispose()
		{
			_provider.Dispose();
		}

		public async Task<int> GetMigrationNumber()
		{
			var responseString = await _provider.GetNestHistoryJsonData();

			var success = JsonDeserializer.TryDeserializeObject(responseString, out JObject responseObject);

			if (success && responseObject?["nestHistoryItems"] != null)
			{
				success = JsonDeserializer.TryDeserializeObject(responseObject["nestHistoryItems"].ToString(),
					out Dictionary<string, NestHistoryItemDto> result);

				if (success)
				{
					return result.FirstOrDefault(item => item.Value.Id != 0).Value.Id;
				}
			}

			return default(int);
		}

		public async Task<List<SilphNestDto>> GetNests()
		{
			var responseString = await _provider.GetLocalNestsJsonData();

			var success = JsonDeserializer.TryDeserializeObject(responseString, out JObject responseObject);

			if (success && responseObject?["localMarkers"] != null)
			{
				success = JsonDeserializer.TryDeserializeObject(responseObject["localMarkers"].ToString(),
					out Dictionary<string, SilphNestDto> result);

				if (success)
				{
					return result.Select(nest => nest.Value).ToList();
				}
			}
			return default(List<SilphNestDto>);
		}
	}
}