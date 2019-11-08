using NUnit.Framework;
using Serilog;
using Serilog.Events;

namespace Nestor.Tests.Logger
{
    [SetUpFixture]
    public class SerilogSetup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .WriteTo.Console()
                .CreateLogger();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Log.CloseAndFlush();
        }
    }
}