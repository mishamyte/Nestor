using Nestor.Domain.Contracts;

namespace Nestor.Domain
{
	internal class NestUpdateRepository : GenericRepository<NestUpdate>, INestUpdateRepository
	{
		public NestUpdateRepository(NestorContext context) : base(context)
		{
		}
	}
}