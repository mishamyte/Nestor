using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nestor.Domain.Contracts
{
	public class Nest
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public int PokemonId { get; set; }

		public NestType NestType { get; set; }

		public double Lat { get; set; }

		public double Lng { get; set; }

		public bool IsRecommended { get; set; }

		public int LastMigration { get; set; }

		public virtual Pokemon Pokemon { get; set; }

		public virtual ICollection<NestUpdate> NestUpdates { get; set; }
	}
}