using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepositoryBase<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return Context.Set<TEntity>();
            }
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
