namespace Nestor.Contracts.Settings
{
	public interface IBotSettings
	{
		string ApiKey { get; set; }

		long ChatId { get; set; }
	}
}
