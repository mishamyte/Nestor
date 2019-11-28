using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nestor.Data.Ef;

namespace Nestor.Service
{
    internal static class HostExtensions
    {
        internal static IHost Migrate(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DbContext>();
            context.Database.Migrate();
            return host;
        }
    }
}