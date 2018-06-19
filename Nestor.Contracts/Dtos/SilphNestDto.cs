using Newtonsoft.Json;

namespace Nestor.Contracts.Dtos
{
	public class SilphNestDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("pokemon_id")]
		public int PokemonId { get; set; }

		[JsonProperty("t")]
		public NestType NestType { get; set; }

		[JsonProperty("lt")]
		public double Lat { get; set; }

		[JsonProperty("ln")]
		public double Lng { get; set; }
	}
}