using System;
using System.ServiceProcess;
using Serilog;

namespace Nestor.Service
{
	public class NestorService : ServiceBase
	{
		private Nestor _nestor;

		protected override void OnStart(string[] args)
		{
			var configReader = new ConfigReader();

			if (configReader.InitConfig())
			{
				_nestor = new Nestor(configReader.Settings, Log.Logger);
				try
				{
					_nestor.Start();
				}
				catch (Exception ex)
				{
					Log.Error(ex, string.Empty);
				}
			}
			else
			{
				Log.Error("Configs weren't loaded!");
			}
		}

		protected override void OnStop()
		{
			_nestor.Stop();
			_nestor.Dispose();
			Log.CloseAndFlush();
		}		
	}
}