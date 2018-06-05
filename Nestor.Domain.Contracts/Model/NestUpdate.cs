using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nestor.Domain.Contracts
{
	public class NestUpdate
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int NestId { get; set; }

		public int PokemonId { get; set; }

		public int MigrationNumber { get; set; }

		public DateTime Timestamp { get; set; }

		public virtual Nest Nest { get; set; }

		public virtual Pokemon Pokemon { get; set; }
	}
}