using Nestor.Model;
using System.Data.Entity;

namespace Nestor.DAL
{
    public class NestsContext : DbContext
    {
        public NestsContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<Nest> Nests { get; set; }
        public DbSet<NestInfo> NestsInfo { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
