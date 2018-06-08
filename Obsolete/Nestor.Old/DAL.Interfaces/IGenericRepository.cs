using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nestor.DAL.Interfaces
{
	/// <summary>
	/// Define generic CRUD operations
	/// </summary>
	internal interface IGenericRepository<TEntity> where TEntity : class
    {
		void Delete(object id);

		void Delete(TEntity entityToDelete);

		IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null);

		TEntity GetById(object id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);
    }
}
