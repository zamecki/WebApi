using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.ApiClient.Models;

namespace WebApplication.ApiClient.ServiceInterface
{
    public interface ICatService
    {
        Task<Cat> GetCatAsync(string catId);
        Task<Cat> GetRandomCatAsync();
    }
}
