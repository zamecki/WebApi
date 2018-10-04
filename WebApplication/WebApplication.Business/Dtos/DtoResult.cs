using System;
using System.Collections.Generic;
using System.Linq;
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
}