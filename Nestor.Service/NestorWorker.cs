using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nestor.Core;

namespace Nestor.Service
{
    internal class NestorWorker : IHostedService, IDisposable
    {
        private readonly ILogger<NestorWorker> _logger;
        private readonly int _pollingFrequency;
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public NestorWorker(ILogger<NestorWorker> logger, IServiceProvider serviceProvider, Settings settings)
        {
            _logger = logger;
            _pollingFrequency = settings.Parser.PollingFrequency;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(_pollingFrequency));
            _logger.LogInformation("NestorWorker is starting");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _logger.LogInformation("NestorWorker is stopping");
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using var scope = _serviceProvider.CreateScope();
            var nestor = scope.ServiceProvider.GetRequiredService<Nestor>();
            await nestor.ProcessNests();
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _logger.LogDebug("NestorWorker is disposing");
        }
    }
}