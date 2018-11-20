using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace TaxiDriver.Services
{
    public class GenericRepository<TEntity> : Interfaces.IGenericRepository<TEntity> where TEntity : class
    {
        // FIELDS
        internal Context.DriverContext context;
        internal DbSet<TEntity> dbSet;
        // CONSTRUCTORS
        public GenericRepository(Context.DriverContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        // PROPERTIES
        public int Count => dbSet.Count();
        // METHODS
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                                                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            Delete(dbSet.Find(id));
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
