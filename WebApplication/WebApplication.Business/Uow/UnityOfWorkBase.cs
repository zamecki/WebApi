using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Business.Uow
{
    public abstract class UnityOfWorkBase<T> : IDisposable
                where T : DbContext, new()
    {
        public UnityOfWorkBase(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        protected void CreateDbContext()
        {
            DbContext = new T();
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        protected IRepository<TEntity> GetStandardRepo<TEntity>() where TEntity : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<TEntity>();
        }
        protected TEntity GetRepo<TEntity>() where TEntity : class
        {
            return RepositoryProvider.GetRepository<TEntity>();
        }

        protected T DbContext { get; set; }


        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
