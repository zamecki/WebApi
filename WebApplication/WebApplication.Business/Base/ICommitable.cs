using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Business.Base
{
    public interface ICommitable
    {
        void Commit();

        Task<int> CommitAsync();
    }
}
