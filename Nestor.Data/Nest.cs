using System.Collections.Generic;

namespace Nestor.Data
{
    public class Nest : BaseNamedEntity
    {
        public Nest()
        {
            NestUpdates = new HashSet<NestUpdate>();
        }

        public string HashtagName { get; set; }

        public int PokemonId { get; set; }
        
        public NestType NestType { get; set; }
        
        public double Lat { get; set; }

        public double Lng { get; set; }

        public bool IsRecommended { get; set; }

        public int LastMigration { get; set; }

        public Pokemon Pokemon { get; set; }

        public ICollection<NestUpdate> NestUpdates { get; set; }
    }
}