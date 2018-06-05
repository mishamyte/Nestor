namespace Nestor.Contracts
{
	public interface IBotSettings
	{
		string ApiKey { get; set; }

		long ChatId { get; set; }
	}
}
