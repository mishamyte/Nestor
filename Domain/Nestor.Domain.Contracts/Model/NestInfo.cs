using System.ComponentModel.DataAnnotations.Schema;

namespace Nestor.Domain.Contracts
{
	public class NestInfo
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string HashtagName { get; set; }
	}
}