using Nestor.Domain.Contracts;

namespace Nestor.Domain
{
	internal class NestInfoRepository : GenericRepository<NestInfo>, INestInfoRepository
	{
		public NestInfoRepository(NestorContext context) : base(context)
		{
		}
	}
}