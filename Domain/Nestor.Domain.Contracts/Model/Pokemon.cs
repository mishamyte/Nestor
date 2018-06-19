using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nestor.Domain.Contracts
{
	public class Pokemon
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Nest> Nests { get; set; }

		public virtual ICollection<NestUpdate> NestUpdates { get; set; }
	}
}