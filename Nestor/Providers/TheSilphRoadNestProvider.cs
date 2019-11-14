using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nestor.Core.Dto;
using Nestor.Core.Providers;
using Nestor.Core.Services;
using Nestor.Utils;

namespace Nestor.Providers
{
    public class TheSilphRoadNestProvider : INestProvider
    {
        private readonly ILogger<TheSilphRoadNestProvider> _logger;
        private readonly ITheSilphRoadService _silphRoadService;

        public TheSilphRoadNestProvider(ILogger<TheSilphRoadNestProvider> logger, ITheSilphRoadService silphRoadService)
        {
            _logger = logger;
            _silphRoadService = silphRoadService ?? throw new ArgumentNullException(nameof(silphRoadService));
        }

        public async Task<int> GetMigrationNumber()
        {
            var response = await _silphRoadService.GetNestHistory();

            try
            {
                using var document = JsonDocument.Parse(response);
                return document.RootElement
                    .GetProperty("nestHistoryItems").EnumerateObject()
                    .Select(p => int.Parse(p.Value.GetProperty("id").GetString()))
                    .First();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting migration number from {response}");
            }

            return default;
        }

        public async Task<IEnumerable<NestDto>> GetNests()
        {
            var response = await _silphRoadService.GetLocalNests();

            try
            {
                using var document = JsonDocument.Parse(response);
                return document.RootElement.GetProperty("localMarkers").EnumerateObject()
                    .Select(p => JsonSerializer.Deserialize<NestDto>(p.Value.ToString(), GetJsonSerializerOptions()))
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting nests from {response}");
            }

            return Enumerable.Empty<NestDto>();
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