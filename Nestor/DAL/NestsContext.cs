using Nestor.Interfaces.Settings;
using Nestor.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Infrastructure.DependencyResolution;

namespace Nestor.DAL
{
    public class NestsContext : DbContext
    {
        private const string DefaultSchema = "nestor";
        private readonly IDbSettings _dbSettings;

	    static NestsContext()
	    {
		    Database.SetInitializer<NestsContext>(null);
	    }

        public NestsContext(IDbSettings dbSettings) : base(dbSettings.ConnectionString)
        {
            _dbSettings = dbSettings;
        }

        public DbSet<Nest> Nests { get; set; }
        public DbSet<NestInfo> NestsInfo { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.HasDefaultSchema(
                string.IsNullOrWhiteSpace(_dbSettings.Schema) ?
                DefaultSchema :
                _dbSettings.Schema);

            if (_dbSettings.LowerFirstLetter)
            {
                modelBuilder.Properties().Configure(c =>
                    c.HasColumnName(ToLower(c.ClrPropertyInfo.Name, false)));
                modelBuilder.Types().Configure(t =>
                    t.ToTable(ToLower(t.ClrType.Name, true)));
            }
        }

        private string ToLower(string value, bool pluralize)
        {
            if (pluralize)
            {
                var pluralizationService = DbConfiguration.DependencyResolver.GetService<IPluralizationService>();

                value = pluralizationService.Pluralize(value);
            }

            return char.ToLower(value[0]) + value.Substring(1);
        }
    }
}
