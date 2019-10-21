using System.Collections.Generic;
using Nestor.Core.Data;

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