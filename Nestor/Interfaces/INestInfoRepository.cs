using Nestor.Model;

namespace Nestor.Interfaces
{
    /// <summary>
    /// Defines Nest Info entity specific operations.
    /// Also injection of INestInfoRepository looks better than IGenericRepository'NestInfo
    /// </summary>
    public interface INestInfoRepository : IGenericRepository<NestInfo>
    {
    }
}
