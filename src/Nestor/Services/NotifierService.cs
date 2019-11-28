using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nestor.Core;
using Nestor.Core.Configuration;
using Nestor.Core.Dto;
using Nestor.Core.Providers;
using Nestor.Core.Services;
using Nestor.Utils;

namespace Nestor.Services
{
    public class NotifierService : INotifierService
    {
        private readonly IBotProvider _botProvider;
        private readonly ILogger<NotifierService> _logger;
        private readonly Global _globalSettings;

        public NotifierService(IBotProvider botProvider, ILogger<NotifierService> logger, Settings settings)
        {
            _botProvider = botProvider ?? throw new ArgumentNullException(nameof(botProvider));
            _logger = logger;
            _globalSettings = settings.Global;
        }

        public async Task Notify(NestInfoDto nest)
        {
            if (IsIgnored(nest)) return;
            var description = GetDescriptionString(nest);
            var gMapsUrl =
                GoogleMapsUrlBuilder.GetUrlString(nest, _globalSettings.GoogleMapsKey, _globalSettings.IconsUrlFormat);
            _logger.LogDebug(gMapsUrl);
            await _botProvider.SendImage(gMapsUrl, description);
            _logger.LogInformation("New nest info {@Nest}", nest);
        }

        private static string GetDescriptionString(NestInfoDto nest)
        {
            var sb = new StringBuilder();

            sb.AppendLine("NEW NEST INFO:");
            sb.AppendLine(nest.ToString());
            sb.Append(
                $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}");

            return sb.ToString();
        }

        private bool IsIgnored(NestInfoDto nest)
        {
            if (_globalSettings.IgnoredPokemons.Contains(nest.Pokemon.Id))
            {
                _logger.LogInformation(
                    $"Nest {nest.Id} with pokemon {nest.Pokemon.Id} was excluded from notify. Reason: ignored pokemons list");
                return true;
            }

            if (_globalSettings.IgnoredNests.Contains(nest.Id))
            {
                _logger.LogInformation(
                    $"Nest {nest.Id} with pokemon {nest.Pokemon.Id} was excluded from notify. Reason: ignored nests list");
                return true;
            }

            return false;
        }
    }
}