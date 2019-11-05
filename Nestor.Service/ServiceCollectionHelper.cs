using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nestor.Core;
using Nestor.Core.Database;
using Nestor.Core.Providers;
using Nestor.Core.Services;
using Nestor.Data.Ef;
using Nestor.Providers;
using Nestor.Services;
using Telegram.Bot;

namespace Nestor.Service
{
    internal static class ServiceCollectionHelper
    {
        private const string DbConnectionStringName = "Nestor";

        public static void RegisterServices(HostBuilderContext context, IServiceCollection services)
        {
            services.Configure<Settings>(context.Configuration);
            var settings = new Settings();
            context.Configuration.Bind(settings);
            services.AddSingleton(settings);

            services.AddDbContext<DbContext, NestorContext>(options =>
                options.UseNpgsql(context.Configuration.GetConnectionString(DbConnectionStringName),
                    opt => opt.SetPostgresVersion(new Version(9, 6))));

            services.AddHttpClient<ITheSilphRoadService, TheSilphRoadService>(); // Add Polly policies

            services.AddSingleton<IBotProvider, TelegramBotProvider>();
            services.AddSingleton<ITelegramBotClient, TelegramBotClient>(sp =>
                new TelegramBotClient(settings.Bot.ApiKey, sp.GetRequiredService<IHttpClientFactory>().CreateClient()));

            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<INestProvider, TheSilphRoadNestProvider>();
            services.AddScoped<INotifierService, NotifierService>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<Nestor>();

            services.AddHostedService<NestorWorker>();
        }
    }
}