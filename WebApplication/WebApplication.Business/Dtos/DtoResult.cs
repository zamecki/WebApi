using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication.Business.Dtos
{
    public class DtoResult<T> : DtoResultBase
    {
        /// <summary>
        /// Container com a resposta da requisição.
        /// </summary>
        public T Result { get; set; }
    }
    public class DtoResultAsync<T> : DtoResultBase
    {
        /// <summary>
        /// Container com a resposta da requisição.
        /// </summary>
        public Task<T> ResultAsync { get; set; }
    }
}