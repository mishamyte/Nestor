using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nestor.Interfaces
{
    /// <summary>
    /// Define generic CRUD operations
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
