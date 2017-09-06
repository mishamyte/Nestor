using System;
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
		private readonly IDatabaseProvider _dbProvider;
		private readonly IBotProvider _bot;
		private readonly ILogger _logger;


		public Nestor(IParserSettings parserSettings, IBotSettings botSettings, IDbSettings dbSettings, IGlobalSettings globalSettings, ILogger logger = null)
		{
			_logger = logger ?? new DefaultConsoleLogger();

			_timer = new Timer(parserSettings.ParsingDelay);
			_timer.Elapsed += Tick;

			_globalSettings = globalSettings;
			_theSilphRoadProvider = new TheSilphRoadProvider(parserSettings);
			_parser = new Parser.Parser(_theSilphRoadProvider);
			_dbProvider = new DatabaseProvider(dbSettings);
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
			var silphNests = await _parser.GetNests();
			var dbNests = _dbProvider.NestsRepository.Get().ToList();
			foreach (var silphNest in silphNests)
			{
				if (dbNests.Exists(x => x.Id == silphNest.Id))
				{
					var dbNest = dbNests.Find(x => x.Id == silphNest.Id);
					if (silphNest.PokemonId != dbNest.PokemonId)
					{
						var nest = AttachPokemonEntity(dbNest, silphNest.PokemonId);
						UpdateNest(nest);
						Notify(nest);
					}
				}
				else
				{
					var nest = AttachPokemonEntity(silphNest, silphNest.PokemonId);
					AddNest(nest);
					Notify(nest);
				}
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

		private void Notify(Nest nest)
		{
			switch (_globalSettings.MessageType)
			{
				case MessageType.Image:
					{
						NotifyWithImage(nest);
						break;
					}
				case MessageType.Location:
					{
						NotifyWithLocation(nest);
						break;
					}
				default:
					{
						NotifyWithImage(nest);
						break;
					}
			}
		}

		private void NotifyWithImage(Nest nest)
		{
			var descriptionString = GetDescriptonMessage(nest) +
			                        $"Location: https://maps.google.com/?q={nest.Lat.ToString(CultureInfo.InvariantCulture)},{nest.Lng.ToString(CultureInfo.InvariantCulture)}";
			_bot.SendImage(new Uri(GoogleMapsUrlBuilder.GetUrlString(nest, _globalSettings.GoogleMapsKey)), descriptionString);
		}

		private void NotifyWithLocation(Nest nest)
		{			
			_bot.SendMessage(GetDescriptonMessage(nest));
			_bot.SendLocation((float)nest.Lat, (float)nest.Lng);
		}

		private string GetDescriptonMessage(Nest nest)
		{
			var nestInfo = _dbProvider.NestsInfoRepository.GetById(nest.Id);
			var sb = new StringBuilder();
			if (nestInfo != null)
			{
				sb.AppendLine(nestInfo.HashtagName != null ? $"{nestInfo.Name} #{nestInfo.HashtagName}" : $"{nestInfo.Name}");
				sb.AppendLine($"#{nest.Pokemon.Name} #Migration{_globalSettings.MigrationNumber}");
			}

			return sb.ToString();
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
			_logger.LogDebug("DISPOSED");
		}
	}
}
