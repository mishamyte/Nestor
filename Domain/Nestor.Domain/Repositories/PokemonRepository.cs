using Nestor.Domain.Contracts;

namespace Nestor.Domain
{
	internal class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
	{
		public PokemonRepository(NestorContext context) : base(context)
		{
		}
	}
}