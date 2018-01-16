using Nestor.Model;

namespace Nestor.DAL.Interfaces
{
	/// <summary>
	/// Defines NestUpdate entity specific operations.
	/// Also injection of INestUpdateRepository looks better than IGenericRepository'NestUpdate
	/// </summary>
	internal interface INestUpdateRepository : IGenericRepository<NestUpdate>
	{
	}
}
