using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nestor.Domain.Contracts
{
	public interface IGenericRepository<TEntity> where TEntity: class 
    {
	    void Delete(object id);

	    void Delete(TEntity entityToDelete);

	    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null);

	    TEntity GetById(object id);

	    void Insert(TEntity entity);

	    void Update(TEntity entityToUpdate);
	}
}
