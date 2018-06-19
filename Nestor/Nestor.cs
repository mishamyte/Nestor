using System;
using System.Timers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nestor.Contracts;
using Nestor.Contracts.Settings;
using Nestor.Domain;
using Nestor.Domain.Contracts;
using Serilog;

namespace Nestor
{
	public class Nestor : IDisposable
	{
		private readonly ILogger _logger;
		private readonly INestsWatcher _nestsWatcher;
		private readonly INotifier _notifier;
		private readonly IParser _parser;
		private readonly Timer _timer;
		private WindsorContainer _container;

		static Nestor()
		{
			AutoMapperConfiguration.Configure();
		}

		public Nestor(ISettings settings, ILogger logger)
		{
			BootstrapContainer(settings, logger);

			_logger = _container.Resolve<ILogger>();
			_nestsWatcher = _container.Resolve<INestsWatcher>();
			_notifier = _container.Resolve<INotifier>();
			_parser = _container.Resolve<IParser>();

			_timer = new Timer(settings.ParserSettings.ParsingDelay);
			_timer.Elapsed += Tick;
		}

		public void Dispose()
		{
			_nestsWatcher.Dispose();
			_parser.Dispose();
			_timer.Dispose();

			_logger.Debug("DISPOSED");
		}

		public void Start()
		{
			_timer.Start();

			_logger.Debug("STARTED");
		}

		public void Stop()
		{
			_timer.Stop();

			_logger.Debug("STOPPED");
		}

		private void BootstrapContainer(ISettings settings, ILogger logger)
		{
			_container = new WindsorContainer();

			_container.Register(Component.For<IBotSettings>().Instance(settings.BotSettings));
			_container.Register(Component.For<IDbSettings>().Instance(settings.DbSettings));
			_container.Register(Component.For<IGlobalSettings>().Instance(settings.GlobalSettings));
			_container.Register(Component.For<IParserSettings>().Instance(settings.ParserSettings));
			_container.Register(Component.For<ILogger>().Instance(logger));
			_container.Register(Component.For<INestProvider>().ImplementedBy<TheSilphRoadProvider>());
			_container.Register(Component.For<IParser>().ImplementedBy<Parser>());
			_container.Register(Component.For<IBotProvider>().ImplementedBy<TelegramBot>());
			_container.Register(Component.For<IDatabaseProvider>().ImplementedBy<DatabaseProvider>().LifestyleTransient());
			_container.Register(Component.For<Func<IDatabaseProvider>>().Instance(() => _container.Resolve<IDatabaseProvider>()));
			_container.Register(Component.For<INotifier>().ImplementedBy<Notifier>());
			_container.Register(Component.For<INestsWatcher>().ImplementedBy<NestsWatcher>());
		}

		private async void Tick(object sender, EventArgs e)
		{
			try
			{
				var nests = await _nestsWatcher.GetMissingAndOutdatedNests();

				foreach (var nest in nests)
				{
					_nestsWatcher.ProcessNest(nest);
					_nestsWatcher.RecordNestUpdateToHistory(nest);
					_notifier.Notify(nest);
				}
			}
			catch (Exception ex)
			{
				_logger.Error(ex, "Nestor runtime error");
			}
		}
	}
}