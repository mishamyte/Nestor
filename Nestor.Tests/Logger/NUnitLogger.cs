using System;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace Nestor.Tests.Logger
{
    internal class NUnitLogger<T> : ILogger<T>, IDisposable
    {
        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => this;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Serilog.Log.Logger.ForContext<T>().Write((LogEventLevel) logLevel, formatter(state, exception));
        }

        public void Dispose()
        {
        }
    }
}