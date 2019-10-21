using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nestor.Core.Data;
using Nestor.Core.Database;

namespace Nestor.Database
{
    public abstract class BaseEfUnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        protected readonly DbContext Context;

        private bool _disposed;

        protected BaseEfUnitOfWork(DbContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return _serviceProvider.GetRequiredService<IRepository<TEntity>>();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            if (disposing) Context?.Dispose();
        }
    }
}