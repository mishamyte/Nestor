using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Nestor.Model
{
	public enum NestType
	{
		Cluster = 1,
		FrequentSpawnArea = 2,
		FrequentSpawnPoint = 3,
		Unknown = 4
	}

	public class Nest
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
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
		public int LastMigration { get; set; }
		public virtual Pokemon Pokemon { get; set; }
	}
}
