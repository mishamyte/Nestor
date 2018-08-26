using System;
using System.Net.Http;
using Polly;
using Polly.Wrap;
using Serilog;

namespace Nestor
{
	internal class Policies
	{
		private readonly ILogger _logger;

		public Policies(ILogger logger)
		{
			_logger = logger;

			CreateExternalHttpProviderPolicy();
		}

		public PolicyWrap<HttpResponseMessage> ExternalHttpProviderPolicy { get; private set; }

		private void CreateExternalHttpProviderPolicy()
		{
			var retryPolicy = Policy.Handle<HttpRequestException>()
				.OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
					(result, timeSpan, retryCount, context) =>
					{
						var isException = result.Exception != null;
						_logger.Warning($"Request failed with {{@Result}}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}", isException ? (object)result.Exception : result.Result.StatusCode);
					});

			var circuitBreakerPolicy = Policy.Handle<HttpRequestException>()
				.OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
				.CircuitBreakerAsync(6, TimeSpan.FromMinutes(2),
					onBreak: (result, state, timeSpan, context) =>
					{
						_logger.Warning($"Entering circuit breaker for {timeSpan}.");
					},
					onReset: context =>
					{
						_logger.Warning("Leaving circuit breaker.");
					},
					onHalfOpen: () =>
					{
						_logger.Warning("Trying to leave circuit breaker.");
					});

			ExternalHttpProviderPolicy = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);
		}
	}
}