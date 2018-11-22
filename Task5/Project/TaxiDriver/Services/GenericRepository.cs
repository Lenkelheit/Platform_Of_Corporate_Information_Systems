using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace TaxiDriver.Services
{
    /// <summary>
    /// Represents class that proxy behind data acsess and buisness logic
    /// </summary>
    /// <typeparam name="TEntity">Data class work with</typeparam>
    public class GenericRepository<TEntity> : Interfaces.IGenericRepository<TEntity> where TEntity : class
    {
        // FIELDS
        internal Context.DriverContext context;
        internal DbSet<TEntity> dbSet;
        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor with 1 parameter
        /// </summary>
        /// <param name="context">Data context</param>
        public GenericRepository(Context.DriverContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        // PROPERTIES
        /// <summary>
        /// Property that enale to interact with count of entities in data base
        /// </summary>
        /// <returns>Count of entities</returns>
        public int Count => dbSet.Count();
        // METHODS
        /// <summary>
        /// Method that get data from data base
        /// </summary>
        /// <param name="filter">Filter for data</param>
        /// <param name="orderBy">The order of the received items</param>
        /// <param name="includeProperties">Included properties</param>
        /// <returns>Queried entities collection</returns>
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
        /// <summary>
        /// Method that enable to get entity by id
        /// </summary>
        /// <param name="id">Entities id</param>
        /// <returns>Finded entity</returns>
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        /// <summary>
        /// Inserts data in data base
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        /// <summary>
        /// Deletes object by id
        /// </summary>
        /// <param name="id">Objects id</param>
        public virtual void Delete(object id)
        {
            Delete(dbSet.Find(id));
        }
        /// <summary>
        /// Deletes preset entity
        /// </summary>
        /// <param name="entityToDelete">Entity to delete</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        /// <summary>
        /// Updates data base
        /// </summary>
        /// <param name="entityToUpdate">Entity to update</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
