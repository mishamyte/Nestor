using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Nestor.Data.Ef
{
    public class NestorContext : DbContext
    {
        public NestorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Nest> Nest { get; set; }

        public DbSet<NestUpdate> NestUpdate { get; set; }

        public DbSet<Pokemon> Pokemon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}