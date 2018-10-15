using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> path);
        IQueryable<T> Where(Expression<Func<T, bool>> query);
        void DisableAutoDetectChanges();
        void EnableAutoDetectChanges();
        void RunWithoutDetectChanges(Action<object> action);
        int RunSqlCommand(string sql, params object[] parameters);
    }
}
