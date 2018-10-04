using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Repository
{
    public class RepositoryFactory
    { 
         private IDictionary<Type, Func<DbContext, object>> GetFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>();
        }

        /// <summary>
        /// Constructor that initializes with runtime Code Camper repository factories
        /// </summary>
        public RepositoryFactory()
        {
            _repositoryFactories = GetFactories();
        }

        /// <summary>
        /// Retorna uma factory baseado em um system.Type
        /// </summary>
        /// <typeparam name="T">O tipo de dados que serve como chave na procura por repository.</typeparam>
        /// <returns>A factory responsável pela inicialização do repositoório, senão for encontrada null.</returns>
        /// <remarks>
        /// O parametro type, T, é tipicamente o tipo de um repositório
        /// mas pode ser qualquer tipo, por exemplo, o tipo de uma entidade
        /// </remarks>
        public Func<DbContext, object> GetRepositoryFactory<T>()
        {

            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        /// <summary>
        /// Retorna a fctory para um <see cref="IRepository{T}"/> onde T é o tipo de uma entidade.
        /// </summary>
        /// <typeparam name="T">O tipo da entidade do repositório de dados.</typeparam>
        /// <returns>
        /// Uma factory reponsável por criar o <see cref="IRepository{T}"/>, dado um <see cref="DbContext"/>.
        /// </returns>
        /// <remarks>
        /// Primeiro busca por uma factory específica <see cref="_repositoryFactories"/>.
        /// Caso não seja encontada, a factory default é utilizada <see cref="DefaultEntityRepositoryFactory{T}"/>.
        /// Você pode substituir uma factory para um tipo "T" adicionando esse mapeamento no método <see cref="GetFactories"/>         
        /// </remarks>
        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        /// <summary>
        /// Factory default para um <see cref="IRepository{T}"/> onde T é uma entidade.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade que um repositório irá manipular</typeparam>
        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbcontext => new EFRepository<T>(dbcontext);
        }

        /// <summary>
        /// Retorna um dicionário de funções responsáveis pela fabricação de repositórios.
        /// </summary>
        /// <remarks>
        /// A key do dicionário é um System.Type, geralmente o tipo do repositório
        /// O value é uma função responsável pela inicialização do repositório
        /// que recebe um <see cref="DbContext"/> como argumento argument e retorna
        /// uma instãncia do respositório requisitado.
        /// </remarks>
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

    }
}
