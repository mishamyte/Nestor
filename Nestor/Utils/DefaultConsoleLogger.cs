using System;
using Nestor.Interfaces;

namespace Nestor.Utils
{
	internal class DefaultConsoleLogger : ILogger
	{
		public void LogMessage(string message)
		{
			Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {message}");
		}

		public void LogError(string error)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] ERROR: {error}");
			Console.ResetColor();
		}

		public void LogDebug(string data)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] DEBUG: {data}");
			Console.ResetColor();
		}
	}
}
