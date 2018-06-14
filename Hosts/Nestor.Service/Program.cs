using System;
using System.IO;
using System.ServiceProcess;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Nestor.Service
{
	public class Program
	{
		static Program()
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
					"Config"))
				.AddJsonFile("logger.json")
				.Build();

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();
		}

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
			var configReader = new ConfigReader();

			if (configReader.InitConfig())
			{
				var nestor = new Nestor(configReader.Settings, Log.Logger);

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
				catch (Exception ex)
				{
					Log.Error(ex, string.Empty);
				}
				finally
				{
					nestor.Dispose();
					Log.CloseAndFlush();
				}
			}
			else
			{
				Log.Error("Configs weren't loaded!");
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