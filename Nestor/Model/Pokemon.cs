using System.Collections.Generic;

namespace Nestor.Model
{
	public class Pokemon
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Nest> Nests { get; set; } 
	}
}
