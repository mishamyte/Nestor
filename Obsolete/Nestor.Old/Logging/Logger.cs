using System.Collections.Generic;

namespace Nestor.Logging
{
	public static class Logger
	{
		private static readonly List<ILogger> Loggers = new List<ILogger>();

		public static void RegisterLogger(ILogger logger)
		{
			if (!Loggers.Contains(logger))
				Loggers.Add(logger);
		}

		public static void LogMessage(string message)
		{
			foreach (var logger in Loggers)
			{
				logger?.LogMessage(message);
			}
		}

		public static void LogError(string error)
		{
			foreach (var logger in Loggers)
			{
				logger?.LogError(error);
			}
		}

		public static void LogDebug(string data)
		{
			foreach (var logger in Loggers)
			{
				logger?.LogDebug(data);
			}
		}
	}
}
