using Nestor.Model;

namespace Nestor.Interfaces
{
    /// <summary>
    /// Defines Pokemon entity specific operations.
    /// Also injection of IPokemonRepository looks better than IGenericRepository'Pokemon
    /// </summary>
    public interface IPokemonRepository : IGenericRepository<Pokemon>
    {
    }
}
