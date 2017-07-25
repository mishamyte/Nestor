using Nestor.Interfaces;
using Nestor.Model;

namespace Nestor.DAL
{
    public class NestInfoRepository : GenericRepository<NestInfo>, INestInfoRepository
    {
        public NestInfoRepository(NestsContext context) : base(context)
        {

        }
    }
}
