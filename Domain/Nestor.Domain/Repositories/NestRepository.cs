using Nestor.Domain.Contracts;

namespace Nestor.Domain
{
	internal class NestRepository : GenericRepository<Nest>, INestRepository
	{
		public NestRepository(NestorContext context) : base(context)
		{
		}
	}
}