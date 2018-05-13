using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Common.Data.Infrastructure
{
    public interface IRepository<T> 
            where T : class
    {
        DbContext UnderlyingDbContext { get; }
        DbSet<T> DbSet { get; }
        void Add(T entity);
        void Update(T entity);
        void Update(T entity, Expression<Func<T, object>> expId);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(int Id);
        T GetById(long Id);
        T GetById(string Id);
        T GetById(Guid Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateAsync(T entity, Expression<Func<T, object>> expId);
        Task DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(int Id);
        Task<T> GetByIdAsync(long Id);
        Task<T> GetByIdAsync(string Id);
        Task<T> GetByIdAsync(Guid Id);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);
    }
}
