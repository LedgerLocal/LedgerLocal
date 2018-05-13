using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Data.Infrastructure
{
    public class RepositoryBase<T, D> : IRepository<T>
            where T : class
            where D : DbContext
    {

        public RepositoryBase(IDatabaseFactory<D> databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDatabaseFactory<D> DatabaseFactory
        {
            get;
            private set;
        }

        protected virtual D DataContext
        {
            get 
            {
                return DatabaseFactory.Get();
            }
        }

        public DbSet<T> DbSet
        {
            get
            {
                return DataContext.Set<T>();
            }
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(T entity, Expression<Func<T, object>> expId)
        {
            var funcId = expId.Compile();
            var valueId = funcId(entity);

            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = DataContext.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                T attachedEntity = DbSet.Find(valueId);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = DataContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = DbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                DbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetById(long id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where).FirstOrDefault<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Factory.StartNew(() =>
            {
                Update(entity);
            });
        }

        public async Task UpdateAsync(T entity, Expression<Func<T, object>> expId)
        {
            await Task.Factory.StartNew(() =>
            {
                Update(entity, expId);
            });
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Factory.StartNew(() =>
            {
                Delete(entity);
            });
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            await Task.Factory.StartNew(() =>
            {
                Delete(where);
            });
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<T> GetByIdAsync(long Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.SingleAsync(where);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToArrayAsync();
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> res = null;

            await Task.Factory.StartNew(() =>
            {
                res = GetMany(where);
            });

            return res;
        }

        public DbContext UnderlyingDbContext
        {
            get 
            {
                return DataContext;
            }
        }
    }
}
