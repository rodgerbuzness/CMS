using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ModelService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunctionService
{
    public class FunctionalSVC : IFunctionalSvc
    {
        private readonly AdminUserOptions _AdminUserOptions;
        private readonly AppUserOptions _AppUserOptions;
        private readonly UserManager<ApplicationUser> _UserManager;

        public FunctionalSVC(IOptions<AppUserOptions> appUserOptions,IOptions<AdminUserOptions> adminUserOptions,UserManager<ApplicationUser> userManager)
        {
            _AdminUserOptions = adminUserOptions.Value;
            _AppUserOptions = appUserOptions.Value;
            _UserManager = userManager;
        }

        public async Task CreateDefaultAdminUser()
        {
            try
            {
                var adminUser = new ApplicationUser
                {
                    Email = _AdminUserOptions.Email,
                    UserName = _AdminUserOptions.Username,
                    EmailConfirmed = true,
                    ProfilePic =  GetDefaultProfilePic(),
                    PhoneNumber = "0745212601",
                    PhoneNumberConfirmed = true,
                    FirstName = _AdminUserOptions.FirstName,
                    LastName = _AdminUserOptions.LastName,
                    UserRole = "Administrator",
                    IsActive = true,
                    UserAddresses = new List<Address>
                    {
                        new Address{Country = _AdminUserOptions.Country, Type="Billing"},
                        new Address{Country = _AdminUserOptions.Country, Type="Shipping"}
                    }
                };

                var result = await _UserManager.CreateAsync(adminUser, _AdminUserOptions.Password);

                if (result.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(adminUser, "Administrator");
                }
            }
            catch (Exception e)
            {

            }
        }

        private string GetDefaultProfilePic()
        {
            return string.Empty;
        }

        public async Task CreateDefaultUser()
        {
            try
            {
                var appUser = new ApplicationUser
                {
                    Email = _AppUserOptions.Email,
                    UserName = _AppUserOptions.Username,
                    EmailConfirmed = true,
                    ProfilePic = GetDefaultProfilePic(),
                    PhoneNumber = "0755266440",
                    PhoneNumberConfirmed = true,
                    FirstName = _AdminUserOptions.FirstName,
                    LastName = _AdminUserOptions.LastName,
                    UserRole = "Customer",
                    IsActive = true,
                    UserAddresses = new List<Address>
                    {
                        new Address{Country = _AdminUserOptions.Country, Type="Billing"},
                        new Address{Country = _AdminUserOptions.Country, Type="Shipping"}
                    }
                };

                var result = await _UserManager.CreateAsync(appUser, _AdminUserOptions.Password);

                if (result.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(appUser, "Customer");
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
