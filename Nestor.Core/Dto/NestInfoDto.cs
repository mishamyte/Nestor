using System.Text;

namespace Nestor.Core.Dto
{
    public class NestInfoDto
    {
        public int Id { get; set; }

        public bool IsRecommended { get; set; }

        public string HashtagName { get; set; }

        public int LastMigration { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Name { get; set; }

        public string NestType { get; set; }

        public PokemonDto Pokemon { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Name))
                sb.AppendLine(!string.IsNullOrEmpty(HashtagName) ? $"{Name} #{HashtagName}" : $"{Name}");

            if (IsRecommended) sb.AppendLine("🔥 RECOMMENDED NEST 🔥");
            if (!string.IsNullOrEmpty(NestType)) sb.AppendLine(NestType);

            sb.Append($"#{Pokemon.Name} #Migration{LastMigration}");

            return sb.ToString();
        }
    }
}