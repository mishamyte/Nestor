using Nestor.DAL.Interfaces;
using Nestor.Model;

namespace Nestor.DAL
{
	internal class NestUpdateRepository : GenericRepository<NestUpdate>, INestUpdateRepository
	{
		internal NestUpdateRepository(NestsContext context) : base(context)
		{
		}
	}
}
