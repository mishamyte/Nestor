using Nestor.Model;

namespace Nestor.DAL.Interfaces
{
	/// <summary>
	/// Defines Nest entity specific operations.
	/// Also injection of INestRepository looks better than IGenericRepository'Nest
	/// </summary>
	internal interface INestRepository : IGenericRepository<Nest>
    {
    }
}
