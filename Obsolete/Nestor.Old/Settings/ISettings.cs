namespace Nestor.Settings
{
	public interface ISettings
	{
		IBotSettings BotSettings { get; set; }

		IDbSettings DbSettings { get; set; }

		IGlobalSettings GlobalSettings { get; set; }

		IParserSettings ParserSettings { get; set; }
	}
}
