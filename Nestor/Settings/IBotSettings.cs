namespace Nestor.Settings
{
	public interface IBotSettings
	{
		string ApiKey { get; set; }

		long ChatId { get; set; }
	}
}
