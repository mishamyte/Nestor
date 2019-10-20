using System.Collections.Generic;

namespace Nestor.Data
{
    public class Pokemon : BaseNamedEntity
    {
        public Pokemon()
        {
            Nests = new HashSet<Nest>();
            NestUpdates = new HashSet<NestUpdate>();
        }

        public ICollection<Nest> Nests { get; set; }

        public ICollection<NestUpdate> NestUpdates { get; set; }
    }
}