using System.IO;
using Nestor.Logging;
using Nestor.Service.Settings;
using Nestor.Service.Utils;
using Nestor.Settings;

namespace Nestor.Service
{
	public class ConfigReader
	{
		private readonly ILogger _logger;

		private BotSettings _botSettings;
		private DbSettings _dbSettings;
		private GlobalSettings _globalSettings;
		private ParserSettings _parserSettings;
		private Settings.Settings _settings;

		public ConfigReader(ILogger logger)
		{
			_logger = logger;
		}

		public ISettings Settings => _settings ?? (_settings = new Settings.Settings());

		public bool InitConfig()
		{
			_settings = new Settings.Settings();
			_botSettings = new BotSettings();
			_dbSettings = new DbSettings();
			_globalSettings = new GlobalSettings();
			_parserSettings = new ParserSettings();

			return DeserializeAllConfigs();
		}

		private static bool ConfigFileExist(string fileName)
		{
			var configPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
				"Config", fileName);

			return File.Exists(configPath);
		}

		private bool DeserializeAllConfigs()
		{
			var result = DeserializeConfigFile("bot.json", out _botSettings);
			result = result && DeserializeConfigFile("db.json", out _dbSettings);
			result = result && DeserializeConfigFile("global.json", out _globalSettings);
			result = result && DeserializeConfigFile("parser.json", out _parserSettings);

			_settings.BotSettings = _botSettings;
			_settings.DbSettings = _dbSettings;
			_settings.GlobalSettings = _globalSettings;
			_settings.ParserSettings = _parserSettings;

			return result;
		}

		private bool DeserializeConfigFile<T>(string fileName, out T config)
		{
			if (!ConfigFileExist(fileName))
			{
				_logger.LogError($"Config file {fileName} doesn't exists!");
				config = default(T);
				return false;
			}

			var filePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
				"Config", fileName);
			bool result;

			using (var sr = new StreamReader(filePath))
			{
				var dataString = sr.ReadToEnd();
				result = JsonDeserializer.TryDeserializeObject(dataString, out config);
			}
			if (!result) _logger.LogError($"Can't deserialize {fileName}");
			return result;
		}
	}
}
