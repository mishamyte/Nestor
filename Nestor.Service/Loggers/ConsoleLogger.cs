using System;
using Nestor.Logging;

namespace Nestor.Service.Loggers
{
	internal class ConsoleLogger : ILogger
	{
		public void LogDebug(string data)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] DEBUG: {data}");
			Console.ResetColor();
		}

		public void LogError(string error)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] ERROR: {error}");
			Console.ResetColor();
		}

		public void LogMessage(string message)
		{
			Console.WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {message}");
		}
	}
}
