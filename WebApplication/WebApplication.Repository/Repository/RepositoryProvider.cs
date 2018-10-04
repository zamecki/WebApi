using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Repository
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public RepositoryProvider(RepositoryFactory repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            _repositories = new Dictionary<Type, object>();
        }
        public DbContext DbContext { get; set; }

        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            // Verifica se uma instância de repositório já foi criada e está em cache
            object repoObj;
            _repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            // se não encontrada ou null; fabricar uma, adicionar a cache, e retorna-la.
            return MakeRepository<T>(factory, DbContext);
        }

        public void SetRepository<T>(T repository)
        {
            throw new NotImplementedException();
        }

        /// <summary>Cria um repositório para o tipo T.</summary>
        /// <typeparam name="T">Tipo do repositório a ser fabricado.</typeparam>
        /// <param name="dbContext">
        /// O <see cref="DbContext"/> que será utilizado para iniciar o repositório.
        /// </param>        
        /// <param name="factory">
        /// A factory que será utilizada para instânciar o repositório utilizando o 
        /// <see cref="DbContext"/>.
        /// </param>
        /// <returns></returns>
        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("Nenhuma factory encontrada para o tipo, " + typeof(T).FullName);
            }
            var repo = (T)f(dbContext);
            _repositories[typeof(T)] = repo;
            return repo;
        }


        private readonly RepositoryFactory _repositoryFactories;

        private readonly Dictionary<Type, object> _repositories;

    }
}
