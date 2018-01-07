using Nestor.DAL.Interfaces;
using Nestor.Model;

namespace Nestor.DAL
{
	internal class NestRepository : GenericRepository<Nest>, INestRepository
    {
	    internal NestRepository(NestsContext context) : base(context)
        {

        }
    }
}
