﻿using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Timers;
using Nestor.DAL;
using Nestor.Interfaces;
using Nestor.Interfaces.Settings;
using Nestor.Model;
using Nestor.Parser;
using Nestor.TelegramBot;
using Nestor.Utils;

namespace Nestor
{
	public class Nestor : IDisposable
	{
		private readonly Timer _timer;
		private readonly Parser.Parser _parser;
		private readonly TheSilphRoadProvider _theSilphRoadProvider;
		private readonly IGlobalSettings _globalSettings;
		private readonly IDbSettings _dbSettings;
		private readonly IBotProvider _bot;
		private readonly ILogger _logger;
		private IDatabaseProvider _dbProvider;


		public Nestor(IParserSettings parserSettings, IBotSettings botSettings, IDbSettings dbSettings, IGlobalSettings globalSettings, ILogger logger = null)
		{
			_logger = logger ?? new DefaultConsoleLogger();

			_timer = new Timer(parserSettings.ParsingDelay);
			_timer.Elapsed += Tick;

			_globalSettings = globalSettings;
			_dbSettings = dbSettings;
			_theSilphRoadProvider = new TheSilphRoadProvider(parserSettings);
			_parser = new Parser.Parser(_theSilphRoadProvider);
			_bot = new Bot(botSettings, _logger);
		}

		public void Start()
		{
			_timer.Start();
			_logger.LogDebug("STARTED");
		}

		public void Stop()
		{
			_timer.Stop();
			_logger.LogDebug("STOPPED");
		}

		private async void Tick(object sender, EventArgs e)
		{
			try
			{
				_dbProvider = new DatabaseProvider(_dbSettings);
				var silphNests = await _parser.GetNests();
				var dbNests = _dbProvider.NestsRepository.Get().ToList();
				if (silphNests != null)
				{
					foreach (var silphNest in silphNests)
					{
						if (dbNests.Exists(x => x.Id == silphNest.Id))
						{
							var dbNest = dbNests.Find(x => x.Id == silphNest.Id);
							if (silphNest.PokemonId != dbNest.PokemonId)
							{
								var nest = AttachPokemonEntity(dbNest, silphNest.PokemonId);
								var isUpdate = dbNest.LastMigration == _globalSettings.MigrationNumber;
								nest.LastMigration = _globalSettings.MigrationNumber;
								UpdateNest(nest);
								Notify(nest, isUpdate);
							}
						}
						else
						{
							var nest = AttachPokemonEntity(silphNest, silphNest.PokemonId);
							nest.LastMigration = _globalSettings.MigrationNumber;
							AddNest(nest);
							Notify(nest);
						}
					}
				}
				else
				{
					_logger.LogDebug("Empty parser response");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.ToString());
			}
			finally
			{
				Dispose();
			}
		}

		private void AddNest(Nest nest)
		{
			_dbProvider.NestsRepository.Insert(nest);
			_dbProvider.Save();
			_logger.LogMessage($"NEST ADDED: {nest.Id}\t{nest.Pokemon.Name}");
		}

		private void UpdateNest(Nest nest)
		{
			_dbProvider.NestsRepository.Update(nest);
			_dbProvider.Save();
			_logger.LogMessage($"NEST UPDATED: {nest.Id}\t{nest.Pokemon.Name}");
		}

		private void Notify(Nest nest, bool isUpdate = false)
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
					{
						NotifyWithImage(nest, isUpdate);
						break;
					}
			}
		}

		private void NotifyWithImage(Nest nest, bool isUpdate)
		{
			var descriptionString = isUpdate
				? $"NEST INFO UPDATED:{Environment.NewLine}" + GetDescriptonMessage(nest) +
				  $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}"
				: GetDescriptonMessage(nest) +
				  $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}";
			_bot.SendImage(new Uri(GoogleMapsUrlBuilder.GetUrlString(nest, _globalSettings.GoogleMapsKey)), descriptionString);
		}

		private void NotifyWithLocation(Nest nest, bool isUpdate)
		{
			var descriptionString = isUpdate
				? $"NEST INFO UPDATED:{Environment.NewLine}" + GetDescriptonMessage(nest)
				: GetDescriptonMessage(nest);
			_bot.SendMessage(descriptionString);
			_bot.SendLocation((float)nest.Lat, (float)nest.Lng);
		}

		private string GetDescriptonMessage(Nest nest)
		{
			var nestInfo = _dbProvider.NestsInfoRepository.GetById(nest.Id);
			var sb = new StringBuilder();
			if (nestInfo != null)
			{
				sb.AppendLine(nestInfo.HashtagName != null
					? $"{nestInfo.Name} #{nestInfo.HashtagName}"
					: $"{nestInfo.Name}");
			}
			sb.AppendLine(GetNestTypeName(nest.NestType));
			sb.AppendLine($"#{nest.Pokemon.Name} #Migration{_globalSettings.MigrationNumber}");

			return sb.ToString();
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

		private Nest AttachPokemonEntity(Nest nest, int pokemonId)
		{
			var pokemon = _dbProvider.PokemonsRepository.GetById(pokemonId);
			nest.PokemonId = pokemon.Id;
			nest.Pokemon = pokemon;
			return nest;
		}

		public void Dispose()
		{
			_timer.Dispose();
			_theSilphRoadProvider.Dispose();
			_dbProvider.Dispose();
			_logger.LogDebug("DISPOSED");
		}
	}
}
