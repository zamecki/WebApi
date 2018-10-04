using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication.Business.Dtos
{
    public class DtoResultBase
    {
        public DtoResultBase()
        {
            StatusCode = HttpStatusCode.OK;
            Message = string.Empty;
        }

        /// <summary>
        /// Status da raquisição
        /// </summary>
        /// <remarks>
        /// 200: Ok
        /// 400: Exceção a regra de negócio
        /// 500: Erro interno no servidor
        /// </remarks>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Mesagem de exceção, só preenchida quando o StatusCode for 500 ou 404.
        /// </summary>
        public string Message { get; set; }
    }
}