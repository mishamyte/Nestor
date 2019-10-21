using System;
using System.Linq;
using Nestor.Core.Data;

namespace Nestor.Core.Database
{
    public interface IRepository<TEntity> : IQueryable<TEntity>, IDisposable where TEntity : BaseEntity
    {
        TEntity Create(TEntity entity);

        void Delete(int id);

        TEntity FindById(int id);

        TEntity Update(TEntity entity);
    }
}