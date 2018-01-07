using Nestor.Model;

namespace Nestor.DTO
{
	internal class NestDto
	{
		internal Nest Nest { get; set; }

		internal NestType NestType { get; set; }
	}

	internal enum NestType
	{
		Missed,
		Outdated
	}
}
