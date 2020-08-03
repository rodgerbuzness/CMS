﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelService;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1",Name="Administrator", NormalizedName = "ADMINISTRATOR",RoleName= "Administrator", Handle= "administrator",RoleIcon="/uploads/roles/icons/role.png", IsActive= true },
                new { Id = "2",Name="Customer", NormalizedName = "CUSTOMER",RoleName= "Customer", Handle= "customer",RoleIcon= "/uploads/roles/icons/role.png", IsActive= true }
                );
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
