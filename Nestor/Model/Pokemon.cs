using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nestor.Model
{
	public class Pokemon
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Nest> Nests { get; set; } 
	}
}
