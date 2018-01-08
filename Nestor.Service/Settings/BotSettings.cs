using Nestor.Settings;

namespace Nestor.Service.Settings
{
	public class BotSettings : IBotSettings
	{
		public string ApiKey { get; set; }

		public long ChatId { get; set; }
	}
}
