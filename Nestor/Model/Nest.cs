using Newtonsoft.Json;

namespace Nestor.Model
{
	public class Nest
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("pokemon_id")]
		public int PokemonId { get; set; }
		[JsonProperty("lt")]
		public double Lat { get; set; }
		[JsonProperty("ln")]
		public double Lng { get; set; }
		public virtual Pokemon Pokemon { get; set; }
	}
}
