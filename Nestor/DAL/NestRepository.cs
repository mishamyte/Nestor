using Nestor.Interfaces;
using Nestor.Model;

namespace Nestor.DAL
{
    public class NestRepository : GenericRepository<Nest>, INestRepository
    {
        public NestRepository(NestsContext context) : base(context)
        {

        }
    }
}
