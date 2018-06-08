using Nestor.DAL.Interfaces;
using Nestor.Model;

namespace Nestor.DAL
{
	internal class NestInfoRepository : GenericRepository<NestInfo>, INestInfoRepository
    {
	    internal NestInfoRepository(NestsContext context) : base(context)
        {

        }
    }
}
