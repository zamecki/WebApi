using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Repository.Interfaces
{
    public interface IRepositoryProvider
    {
        /// <summary>
        /// Recupera ou seta o <see cref="DbContext"/> que será utilizado pra inicializar instancias de repositórios.
        /// </summary>
        DbContext DbContext { get; set; }

        /// <summary>
        /// Recupera uma intância de <see cref="IRepository{T}"/> pra uma entidade do tipo, T.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo da entidade que será manipulada por <see cref="IRepository{T}"/>.
        /// </typeparam>
        IRepository<T> GetRepositoryForEntityType<T>() where T : class;

        /// <summary>
        /// Retorna uma repositório do tipo T.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo do repositório, tipicamente um repositório customizado.
        /// </typeparam>
        /// <param name="factory">
        /// Uma função opcional utilizada pra criar intâncias de repositórios. Usada se for necessária a criação de uma instância de repositório.
        /// </param>
        /// <remarks>
        /// Verifica se o repositório se encontra em cache, retornando se for encontrado.
        /// Se não for encontrado, tenta criar um repositório utilizando a factory informada no parâmentro, caso nenhuma factory seja informada a factory default será utilizada.
        /// </remarks>
        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;


        /// <summary>
        /// Especifica o repositório que será retornado por este provider.
        /// </summary>
        /// <remarks>
        /// Especifica um provider, caso não queira que esse provider crie um.
        /// Este método é util para testes e desenvolvimento sem backend.
        /// </remarks>
        void SetRepository<T>(T repository);
    }
}
