using System;
using System.Timers;
using Nestor.BusinessLogic;
using Nestor.Logging;
using Nestor.Parser;
using Nestor.Settings;
using NestType = Nestor.DTO.NestType;

namespace Nestor
{
	public class Nestor : IDisposable
	{
		private readonly INestsWatcher _nestsWatcher;
		private readonly INotifier _notifier;
		private readonly IParser _parser;
		private readonly Timer _timer;

		public Nestor(ISettings settings)
		{
			_timer = new Timer(settings.ParserSettings.ParsingDelay);
			_timer.Elapsed += Tick;

			_notifier = new Notifier(settings);
			_parser = new Parser.Parser(new TheSilphRoadProvider(settings.ParserSettings));
			_nestsWatcher = new NestsWatcher(settings);
		}

		public Nestor(ISettings settings, ILogger logger) : this(settings)
		{
			Logger.RegisterLogger(logger);
		}

		public void Start()
		{
			_timer.Start();

			Logger.LogDebug("STARTED");
		}

		public void Stop()
		{
			_timer.Stop();

			Logger.LogDebug("STOPPED");
		}

		private async void Tick(object sender, EventArgs e)
		{
			try
			{
				var nests = await _nestsWatcher.GetMissingAndOutdatedNests();

				foreach (var nest in nests)
				{
					_nestsWatcher.ProcessNest(nest);
					_notifier.Notify(nest.Nest, nest.NestType == NestType.Outdated);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}			
		}

		public void Dispose()
		{
			_nestsWatcher.Dispose();
			_parser.Dispose();
			_timer.Dispose();

			Logger.LogDebug("DISPOSED");
		}
	}
}
