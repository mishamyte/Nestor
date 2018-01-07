using System;
using System.Globalization;
using System.Text;
using Nestor.DAL;
using Nestor.Logging;
using Nestor.Model;
using Nestor.Settings;
using Nestor.TelegramBot;
using Nestor.Utils;

namespace Nestor.BusinessLogic
{
	internal class Notifier : INotifier
	{
		private readonly IBotProvider _bot;
		private readonly ISettings _settings;

		internal Notifier(ISettings settings)
		{
			_settings = settings;

			_bot = new Bot(_settings.BotSettings);
		}

		public void Notify(Nest nest, bool isUpdate = false)
		{
			switch (_settings.GlobalSettings.MessageType)
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
					{
						NotifyWithImage(nest, isUpdate);
						break;
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
				var dbProvider = new DatabaseProvider(_settings.DbSettings);
				var nestInfo = dbProvider.NestsInfoRepository.GetById(nest.Id);
				var sb = new StringBuilder();

				if (nestInfo != null)
				{
					sb.AppendLine(nestInfo.HashtagName != null
						? $"{nestInfo.Name} #{nestInfo.HashtagName}"
						: $"{nestInfo.Name}");
				}
				sb.AppendLine(GetNestTypeName(nest.NestType));
				sb.AppendLine($"#{nest.Pokemon.Name} #Migration{_settings.GlobalSettings.MigrationNumber}");

				return sb.ToString();
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				throw;
			}
		}

		private void NotifyWithImage(Nest nest, bool isUpdate)
		{
			var descriptionString = isUpdate
				? $"NEST INFO UPDATED:{Environment.NewLine}" + GetDescriptionMessage(nest) +
				  $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}"
				: GetDescriptionMessage(nest) +
				  $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}";

			_bot.SendImage(new Uri(GoogleMapsUrlBuilder.GetUrlString(nest, _settings.GlobalSettings.GoogleMapsKey)), descriptionString);
		}

		private void NotifyWithLocation(Nest nest, bool isUpdate)
		{
			var descriptionString = isUpdate
				? $"NEST INFO UPDATED:{Environment.NewLine}" + GetDescriptionMessage(nest)
				: GetDescriptionMessage(nest);

			_bot.SendMessage(descriptionString);
			_bot.SendLocation((float)nest.Lat, (float)nest.Lng);
		}
	}
}
