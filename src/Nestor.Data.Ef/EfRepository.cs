using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Nestor.Core.Data;
using Nestor.Core.Database;

namespace Nestor.Data.Ef
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        private bool _disposed;

        public EfRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public Type ElementType => ((IQueryable<TEntity>) _dbSet).ElementType;

        public Expression Expression => ((IQueryable<TEntity>) _dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable<TEntity>) _dbSet).Provider;

        public TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public IEnumerable<TEntity> CreateMany(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            return entities;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                throw new NullReferenceException($"Entity {typeof(TEntity)} with id {id} was not found");
            _dbSet.Remove(entity);
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public IEnumerable<TEntity> UpdateMany(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return entities;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return ((IQueryable<TEntity>) _dbSet).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
            if (disposing) _context?.Dispose();
        }
    }
}