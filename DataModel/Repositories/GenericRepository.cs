using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel;

namespace DataModel.Repositories
{
    public abstract class GenericRepository<Cntx, TEntity> : IDisposable, IMainRepository<TEntity> where TEntity : class where Cntx : DbContext, new()
    {
        private Cntx _entities = new Cntx();
        public Cntx Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>();
            return query;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            return query;
        }

        public TEntity GetByID(int id)
        {
            TEntity query = _entities.Set<TEntity>().Find(id);
            return query;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _entities.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        #region Implementing IDiosposable...  

        #region private dispose variable declaration...  
        private bool disposed = false;
        #endregion

        /// <summary>  
        /// Protected Virtual Dispose method  
        /// </summary>  
        /// <param name="disposing"></param>  
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>  
        /// Dispose method
        /// </summary>  
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}