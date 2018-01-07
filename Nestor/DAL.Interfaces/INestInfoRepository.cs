using Nestor.Model;

namespace Nestor.DAL.Interfaces
{
	/// <summary>
	/// Defines Nest Info entity specific operations.
	/// Also injection of INestInfoRepository looks better than IGenericRepository'NestInfo
	/// </summary>
	internal interface INestInfoRepository : IGenericRepository<NestInfo>
    {
    }
}
