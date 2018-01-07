using Nestor.DAL.Interfaces;
using Nestor.Model;

namespace Nestor.DAL
{
	internal class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
	    internal PokemonRepository(NestsContext context) : base(context)
        {

        }
    }
}
