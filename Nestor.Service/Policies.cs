using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;

namespace Nestor.Service
{
    internal class Policies
    {
        private readonly ILogger<Policies> _logger;

        public Policies(ILogger<Policies> logger)
        {
            _logger = logger;
        }

        public IAsyncPolicy<HttpResponseMessage> RetryPolicy =>
            HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<TaskCanceledException>()
                .OrResult(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (result, timeSpan, retryCount, context) =>
                    {
                        var isException = result.Exception != null;
                        _logger.LogWarning(
                            $"Request failed with {{@Result}}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}",
                            isException ? (object) result.Exception : result.Result.StatusCode);
                    });

        public IAsyncPolicy<HttpResponseMessage> CircuitBreakerPolicy =>
            HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<TaskCanceledException>()
                .OrResult(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(6, TimeSpan.FromMinutes(2),
                    onBreak: (result, state, timeSpan, context) =>
                    {
                        _logger.LogWarning($"Entering circuit breaker for {timeSpan}.");
                    },
                    onReset: context => { _logger.LogWarning("Leaving circuit breaker."); },
                    onHalfOpen: () => { _logger.LogWarning("Trying to leave circuit breaker."); });
    }
}