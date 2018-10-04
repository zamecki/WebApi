using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models.Models;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Business.Uow
{
    public interface IUnityOfWork : IDisposable
    {
        /// <summary>
        /// Salva as alterações do contexto de dados e realiza a pesistencia das informações no banco de dados.
        /// </summary>
        void Commit();

        /// <summary>
        /// Realiza a persistência dos dados de forma asincrona.
        /// </summary>
        Task<int> CommitAsync();
        IRepository<User> User { get; }
        IRepository<Post> Post { get; }
    }
}
