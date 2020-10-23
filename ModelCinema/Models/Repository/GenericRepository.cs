using ModelCinema.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ModelCinema.Models.Repository
{
    public abstract class GenericRepository<T> where T : class
    {
        protected DbContext db;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.db = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual T Find(T obj)
        {
            if (dbSet.ToList().Where(m => m.Equals(obj)).Count() > 0)
                return dbSet.ToList().Where(m => m.Equals(obj)).First();

            return null;
        }

        public virtual void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public virtual void InsertIfNotExists(T obj)
        {
            if (dbSet.ToList().Where(m => m.Equals(obj)).Count() == 0)
            {
                dbSet.Add(obj);
            }
        }

        public virtual void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public virtual void Delete(T obj)
        {
            T objToDelete = dbSet.Find(obj);
            dbSet.Remove(objToDelete);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}



