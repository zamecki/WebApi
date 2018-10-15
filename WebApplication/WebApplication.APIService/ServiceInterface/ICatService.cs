using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.APIService.ServiceInterface
{
    public interface ICatService
    {
        string GetRandomCat();

        string GetImageURL(string imageID);
    }
}
