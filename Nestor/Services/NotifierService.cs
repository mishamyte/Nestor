using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nestor.Core;
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
        private readonly string _gmapsKey;
        private readonly string _iconsUrlFormat;

        public NotifierService(IBotProvider botProvider, ILogger<NotifierService> logger, Settings settings)
        {
            _botProvider = botProvider ?? throw new ArgumentNullException(nameof(botProvider));
            _logger = logger;
            _gmapsKey = settings.Global.GoogleMapsKey;
            _iconsUrlFormat = settings.Global.IconsUrlFormat;
        }

        public async Task Notify(NestInfoDto nest)
        {
            var description = GetDescriptionString(nest);
            await _botProvider.SendImage(GoogleMapsUrlBuilder.GetUrlString(nest, _gmapsKey, _iconsUrlFormat),
                description);
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
    }
}