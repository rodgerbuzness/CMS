using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
    public class DataProtectionkeysContext : DbContext, IDataProtectionKeyContext
    {
        public DataProtectionkeysContext(DbContextOptions<DataProtectionkeysContext> options) : base(options)
        {

        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    }
}
