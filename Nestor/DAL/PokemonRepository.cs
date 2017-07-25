using Nestor.Interfaces;
using Nestor.Model;

namespace Nestor.DAL
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        public PokemonRepository(NestsContext context) : base(context)
        {

        }
    }
}
