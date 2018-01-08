using System;
using System.IO;
using Nestor.Logging;

namespace Nestor.Service.Loggers
{
	internal class FileLogger : ILogger
	{
		private readonly string _fileName;

		internal FileLogger()
		{
			_fileName = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
				"Logs", $"{DateTime.Now:dd.MM.yyyy HH-mm-ss}.txt");
		}

		public void LogDebug(string data)
		{
			WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] DEBUG: {data}");
		}

		public void LogError(string error)
		{
			WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] ERROR: {error}");
		}

		public void LogMessage(string message)
		{
			WriteLine($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {message}");
		}

		private void WriteLine(string message)
		{
			using (var sw = new StreamWriter(_fileName, true))
			{
				sw.WriteLine(message);
			}
		}
	}
}
