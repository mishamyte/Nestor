using System.Collections.Generic;

namespace Nestor.Core.Configuration
{
    public class Global
    {
        public string GoogleMapsKey { get; set; }

        public string IconsUrlFormat { get; set; }

        public IEnumerable<int> IgnoredNests { get; set; }

        public IEnumerable<int> IgnoredPokemons { get; set; }

        public MessageType MessageType { get; set; }
    }
}