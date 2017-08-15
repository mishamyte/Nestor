namespace Nestor.Interfaces
{
	public interface ILogger
	{
		void LogMessage(string message);
		void LogError(string error);
		void LogDebug(string data);
	}
}
