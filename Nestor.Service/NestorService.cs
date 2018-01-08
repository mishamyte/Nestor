using System;
using System.ServiceProcess;
using Nestor.Service.Loggers;

namespace Nestor.Service
{
	public class NestorService : ServiceBase
	{
		private Nestor _nestor;

		protected override void OnStart(string[] args)
		{
			var logger = new FileLogger();
			var configReader = new ConfigReader(logger);

			if (configReader.InitConfig())
			{
				_nestor = new Nestor(configReader.Settings, logger);
				try
				{
					_nestor.Start();
				}
				catch (Exception e)
				{
					logger.LogError(e.ToString());
				}
			}
			else
			{
				logger.LogError("Configs weren't loaded!");
			}
		}

		protected override void OnStop()
		{
			_nestor.Stop();
			_nestor.Dispose();
		}
	}
}
