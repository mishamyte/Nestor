using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Nestor.Data.Ef;

namespace Nestor.Service
{
    internal class DesignTimeNestorContextFactory : IDesignTimeDbContextFactory<NestorContext>
    {
        private const string DbConnectionStringName = "Nestor";

        public NestorContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<NestorContext>();
            builder.UseNpgsql(configuration.GetConnectionString(DbConnectionStringName),
                options => options.SetPostgresVersion(new Version(9, 6)));

            return new NestorContext(builder.Options);
        }
    }
}