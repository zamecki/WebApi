using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models.Models;
using WebApplication.Repository;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Business.Uow
{
    public class UnityOfWork : UnityOfWorkBase<WebApplicationContext>, IUnityOfWork
    {
        public UnityOfWork(IRepositoryProvider repositoryProvider) : base(repositoryProvider) { }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
        
        public IRepository<User> User
        {
            get { return GetStandardRepo<User>(); }
        }

        public IRepository<Post> Post
        {
            get { return GetStandardRepo<Post>(); }
        }
    }
}
