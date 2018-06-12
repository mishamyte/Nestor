﻿using System;
using System.Globalization;
using System.Text;
using Nestor.DAL;
using Nestor.DAL.Interfaces;
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
		private readonly IGlobalSettings _globalSettings;
		private readonly Func<IDatabaseProvider> _getDbProvider;

		internal Notifier(ISettings settings)
		{
			_bot = new Bot(settings.BotSettings);

			_globalSettings = settings.GlobalSettings;

			_getDbProvider = () => new DatabaseProvider(settings.DbSettings);
		}

		internal Notifier(IGlobalSettings globalSettings, IBotProvider botProvider, Func<IDatabaseProvider> getDbProvider)
		{
			_bot = botProvider;

			_globalSettings = globalSettings;

			_getDbProvider = getDbProvider;
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
				Logger.LogError(ex.ToString());
				throw;
			}
		}

		private bool IsIgnored(Nest nest)
		{
			if (_globalSettings.IgnoredPokemons.Contains(nest.PokemonId))
			{
				Logger.LogMessage(
					$"Nest {nest.Id} with pokemon {nest.PokemonId} was exluded from notify. Reason: ignored pokemons list");
				return true;
			}

			if (_globalSettings.IgnoredNests.Contains(nest.Id))
			{
				Logger.LogMessage(
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

			_bot.SendImage(new Uri(GoogleMapsUrlBuilder.GetUrlString(nest, _globalSettings.GoogleMapsKey, _globalSettings.IconsUrlFormat)), descriptionString);
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