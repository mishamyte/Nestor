using System;
using System.Globalization;
using System.Text;
using Nestor.Contracts;
using Nestor.Contracts.Settings;
using Nestor.Domain.Contracts;
using Nestor.Utils;
using Serilog;

namespace Nestor
{
	public class Notifier : INotifier
	{
		private readonly IBotProvider _bot;
		private readonly Func<IDatabaseProvider> _getDbProvider;
		private readonly IGlobalSettings _globalSettings;
		private readonly ILogger _logger;

		internal Notifier(IGlobalSettings globalSettings, IBotProvider botProvider, Func<IDatabaseProvider> getDbProvider, ILogger logger)
		{
			_bot = botProvider;
			_globalSettings = globalSettings;
			_getDbProvider = getDbProvider;
			_logger = logger;
		}

		public void Notify(Nest nest, bool isUpdate = false)
		{
			if (!IsIgnored(nest))
			{
				switch (_globalSettings.MessageType)
				{
					case MessageType.Image:
					{
						NotifyWithImage(nest, isUpdate);
						break;
					}
					case MessageType.Location:
					{
						NotifyWithLocation(nest, isUpdate);
						break;
					}
					default:
						throw new ArgumentOutOfRangeException($"Unknown message type {_globalSettings.MessageType}");
				}
			}
		}

		private static string GetNestTypeName(NestType nestType)
		{
			switch (nestType)
			{
				case NestType.Cluster:
					return "CLUSTER SPAWN";
				case NestType.FrequentSpawnArea:
					return "FREQUENT SPAWN AREA";
				case NestType.FrequentSpawnPoint:
					return "FREQUENT SPAWN POINT";
				case NestType.Unknown:
					return "UNKNOWN NEST TYPE";
				default:
					return string.Empty;
			}
		}

		private string GetDescriptionMessage(Nest nest)
		{
			try
			{
				using (var dbProvider = _getDbProvider())
				{
					var dbNest = dbProvider.NestsRepository.GetById(nest.Id);
					var nestInfo = dbProvider.NestsInfoRepository.GetById(nest.Id);
					var sb = new StringBuilder();

					if (nestInfo != null)
					{
						sb.AppendLine(nestInfo.HashtagName != null
							? $"{nestInfo.Name} #{nestInfo.HashtagName}"
							: $"{nestInfo.Name}");
					}

					if (nest.IsRecommended)
					{
						sb.AppendLine("🔥 RECOMMENDED NEST 🔥");
					}

					var nestTypeName = GetNestTypeName(dbNest.NestType);

					if (!string.IsNullOrEmpty(nestTypeName))
					{
						sb.AppendLine(nestTypeName);
					}

					sb.AppendLine($"#{dbNest.Pokemon.Name} #Migration{_globalSettings.MigrationNumber}");

					return sb.ToString();
				}
			}
			catch (Exception ex)
			{
				_logger.Error(ex, "Error while building description message");
				throw;
			}
		}

		private bool IsIgnored(Nest nest)
		{
			if (_globalSettings.IgnoredPokemons.Contains(nest.PokemonId))
			{
				_logger.Information(
					$"Nest {nest.Id} with pokemon {nest.PokemonId} was exluded from notify. Reason: ignored pokemons list");				
				return true;
			}

			if (_globalSettings.IgnoredNests.Contains(nest.Id))
			{
				_logger.Information(
					$"Nest {nest.Id} with pokemon {nest.PokemonId} was exluded from notify. Reason: ignored nests list");
				return true;
			}

			return false;
		}

		private void NotifyWithImage(Nest nest, bool isUpdate)
		{
			var descriptionString = isUpdate
				? $"NEST INFO UPDATED:{Environment.NewLine}" + GetDescriptionMessage(nest) +
				  $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}"
				: GetDescriptionMessage(nest) +
				  $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}";

			_bot.SendImage(
				GoogleMapsUrlBuilder.GetUrlString(nest, _globalSettings.GoogleMapsKey, _globalSettings.IconsUrlFormat),
				descriptionString);
		}

		private void NotifyWithLocation(Nest nest, bool isUpdate)
		{
			var descriptionString = isUpdate
				? $"NEST INFO UPDATED:{Environment.NewLine}" + GetDescriptionMessage(nest)
				: GetDescriptionMessage(nest);

			_bot.SendMessage(descriptionString);
			_bot.SendLocation((float) nest.Lat, (float) nest.Lng);
		}
	}
}