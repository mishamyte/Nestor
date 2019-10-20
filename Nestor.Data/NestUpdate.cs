using System;

namespace Nestor.Data
{
    public class NestUpdate : BaseEntity
    {
        public int NestId { get; set; }

        public int PokemonId { get; set; }

        public int MigrationNumber { get; set; }

        public DateTime Timestamp { get; set; }

        public Nest Nest { get; set; }

        public Pokemon Pokemon { get; set; }
    }
}