using NUnit.Framework;
using Serilog;
using Serilog.Events;

namespace Nestor.Tests
{
	[SetUpFixture]
	public class TestsConfiguration
	{

		[OneTimeSetUp]
		public void Init()
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
				.MinimumLevel.Override("System", LogEventLevel.Warning)
				.WriteTo.Console()
				.CreateLogger();
		}

		[OneTimeTearDown]
		public void CleanUp()
		{
			Log.CloseAndFlush();
		}
	}
}