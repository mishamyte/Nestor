using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Nestor.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateGenericHostBuilder(args).Build().Migrate().Run();
        }

        private static IHostBuilder CreateGenericHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(ServiceCollectionHelper.RegisterServices)
                .ConfigureLogging((ctx, cfg) => cfg.ClearProviders())
                .UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
    }
}