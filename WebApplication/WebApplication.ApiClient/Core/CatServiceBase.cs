using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.ApiClient.Core
{
    public abstract class CatServiceBase
    {
        protected HttpClient HttpClient { get; private set; }

        private string BaseURL { get; set; }

        protected CancellationToken CancellationToken { get; private set; }

        public CatServiceBase()
        {
            BaseURL = "https://api.thecatapi.com/v1/";
            CancellationToken = new CancellationToken();
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(BaseURL);
        }

    }
}
