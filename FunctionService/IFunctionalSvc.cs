using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunctionService
{
    public interface IFunctionalSvc
    {
        Task CreateDefaultAdminUser();
        Task CreateDefaultUser();
    }
}
