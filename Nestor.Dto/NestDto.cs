using System.Text.Json.Serialization;

namespace Nestor.Dto
{
    public class NestDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("pokemon_id")]
        public int PokemonId { get; set; }
        
        [JsonPropertyName("t")]
        public int NestType { get; set; }
        
        [JsonPropertyName("lt")]
        public double Lat { get; set; }
        
        [JsonPropertyName("ln")]
        public double Lng { get; set; }
    }
}