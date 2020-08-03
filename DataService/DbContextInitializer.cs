using FunctionService;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public static class DbContextInitializer
    {
        public static async Task Initialize(DataProtectionkeysContext dataProtectionkeysContext,ApplicationDbContext applicationDbContext,IFunctionalSvc functionalSvc)
        {
            await dataProtectionkeysContext.Database.EnsureCreatedAsync();
            await applicationDbContext.Database.EnsureCreatedAsync();

            bool exist = applicationDbContext.ApplicationUsers.Any();

            if (exist)
            {
                return;
            }

            await functionalSvc.CreateDefaultAdminUser();
            await functionalSvc.CreateDefaultUser();
        }
    }
}
