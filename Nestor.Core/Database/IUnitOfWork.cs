using System;
using Nestor.Core.Data;

namespace Nestor.Core.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        void SaveChanges();
    }
}