using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication.ApiClient.Core;
using WebApplication.ApiClient.Models;
using WebApplication.ApiClient.ServiceInterface;

namespace WebApplication.ApiClient.Service
{
    public class CatService : CatServiceBase, ICatService
    {

        public async Task<Cat> GetCatAsync(string catId)
        {
            List<Cat> cats = null;

            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            HttpResponseMessage response = await HttpClient.GetAsync("images/search", CancellationToken);

            if (response.IsSuccessStatusCode)
            {
                cats = await response.Content.ReadAsAsync<List<Cat>>();
            }

            return cats.FirstOrDefault();
        }
        public async Task<Cat> GetRandomCatAsync()
        {
            List<Cat> cats = null;
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            HttpResponseMessage response = await HttpClient.GetAsync("images/search", CancellationToken);

            if (response.IsSuccessStatusCode)
            {
                cats = await response.Content.ReadAsAsync<List<Cat>>();
            }

            return cats.FirstOrDefault();
        }
    }
}
