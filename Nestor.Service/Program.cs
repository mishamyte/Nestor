using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Nestor.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(ServiceCollectionHelper.RegisterServices)
                .ConfigureLogging((ctx, cfg) => cfg.ClearProviders())
                .UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
    }
}