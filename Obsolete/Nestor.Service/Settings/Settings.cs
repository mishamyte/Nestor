using Nestor.Settings;

namespace Nestor.Service.Settings
{
	public class Settings : ISettings
	{
		public IBotSettings BotSettings { get; set; }

		public IDbSettings DbSettings { get; set; }

		public IGlobalSettings GlobalSettings { get; set; }

		public IParserSettings ParserSettings { get; set; }
	}
}
