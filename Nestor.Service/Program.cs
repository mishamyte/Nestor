using System;
using System.ServiceProcess;
using Nestor.Service.Loggers;

namespace Nestor.Service
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (!Environment.UserInteractive)
			{
				RunService();
			}
			else
			{
				RunConsole();
			}
		}

		private static void RunConsole()
		{
			var logger = new ConsoleLogger();
			var configReader = new ConfigReader(logger);

			if (configReader.InitConfig())
			{
				var nestor = new Nestor(configReader.Settings, logger);

				try
				{
					nestor.Start();
					while (true)
					{
						var command = Console.ReadLine();
						if (command.CompareTo("exit") == 0)
						{
							break;
						}
					}
					nestor.Stop();
				}
				catch (Exception e)
				{
					logger.LogError(e.StackTrace);
				}
				finally
				{
					nestor.Dispose();
				}
			}
			else
			{
				logger.LogError("Configs weren't loaded!");
				Console.ReadLine();
			}
		}

		private static void RunService()
		{
			var servicesToRun = new ServiceBase[]
			{
				new NestorService()
			};
			ServiceBase.Run(servicesToRun);
		}
	}
}
