using Nestor.Model;

namespace Nestor.Interfaces
{
    /// <summary>
    /// Defines Nest entity specific operations.
    /// Also injection of INestRepository looks better than IGenericRepository'Nest
    /// </summary>
    public interface INestRepository : IGenericRepository<Nest>
    {
    }
}
