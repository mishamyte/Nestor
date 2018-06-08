using Nestor.Model;

namespace Nestor.DAL.Interfaces
{
	/// <summary>
	/// Defines Pokemon entity specific operations.
	/// Also injection of IPokemonRepository looks better than IGenericRepository'Pokemon
	/// </summary>
	internal interface IPokemonRepository : IGenericRepository<Pokemon>
    {
    }
}
