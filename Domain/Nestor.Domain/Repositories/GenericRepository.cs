using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Nestor.Domain.Contracts;

namespace Nestor.Domain
{
	internal abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected NestorContext Context;
		protected DbSet<TEntity> DbSet;

		protected GenericRepository(NestorContext context)
		{
			Context = context;
			DbSet = context.Set<TEntity>();
		}

		public virtual void Delete(object id)
		{
			var entityToDelete = DbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (Context.Entry(entityToDelete).State == EntityState.Detached)
			{
				DbSet.Attach(entityToDelete);
			}

			DbSet.Remove(entityToDelete);
		}

		public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
		{
			IQueryable<TEntity> query = DbSet;

			if (where != null)
			{
				query = query.Where(where);
			}

			return query.ToList();
		}

		public virtual TEntity GetById(object id)
		{
			return DbSet.Find(id);
		}

		public virtual void Insert(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			DbSet.Attach(entityToUpdate);
			Context.Entry(entityToUpdate).State = EntityState.Modified;
		}
	}
}