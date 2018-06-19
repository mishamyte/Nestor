using System;
using Newtonsoft.Json;

namespace Nestor.Contracts.Dtos
{
	public class NestHistoryItemDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("migration_timestamp")]
		public DateTime MigrationTimestamp { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("created")]
		public DateTime Created { get; set; }

		[JsonProperty("modified")]
		public DateTime Modified { get; set; }

		[JsonProperty("is_verification_report")]
		public bool IsVerificationReport { get; set; }

		[JsonProperty("created_timestamp")]
		public long CreatedTimestamp { get; set; }

		[JsonProperty("created_date")]
		public string CreatedDate { get; set; }

		[JsonProperty("created_year")]
		public string CreatedYear { get; set; }
	}
}