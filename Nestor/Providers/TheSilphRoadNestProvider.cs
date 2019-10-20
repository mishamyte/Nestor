using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Nestor.Core.Providers;
using Nestor.Core.Services;
using Nestor.Dto;
using Nestor.Utils;

namespace Nestor.Providers
{
    public class TheSilphRoadNestProvider : INestProvider
    {
        private readonly ITheSilphRoadService _silphRoadService;

        public TheSilphRoadNestProvider(ITheSilphRoadService silphRoadService)
        {
            _silphRoadService = silphRoadService ?? throw new ArgumentNullException(nameof(silphRoadService));
        }

        public async Task<int> GetMigrationNumber()
        {
            var response = await _silphRoadService.GetNestHistory();
            using var document = JsonDocument.Parse(response);

            return document.RootElement
                .GetProperty("nestHistoryItems").EnumerateObject()
                .Select(p => int.Parse(p.Value.GetProperty("id").GetString()))
                .First();
        }

        public async Task<IEnumerable<NestDto>> GetNests()
        {
            var response = await _silphRoadService.GetLocalNests();
            using var document = JsonDocument.Parse(response);

            return document.RootElement.GetProperty("localMarkers").EnumerateObject()
                .Select(p => JsonSerializer.Deserialize<NestDto>(p.Value.ToString(), GetJsonSerializerOptions()))
                .ToList();
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                Converters = {new IntJsonConverter(), new DoubleJsonConverter()}
            };
        }
    }
}