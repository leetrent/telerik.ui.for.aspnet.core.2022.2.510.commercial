using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models
{
    public class CustomerEntitiesDataContext : DbContext
    {
        public CustomerEntitiesDataContext() : base(new DbContextOptions<CustomerEntitiesDataContext>())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dataDirectory = Path.Combine(Startup.WebRootPath, "App_Data");

            options.UseSqlite(@"Data Source=" + dataDirectory + System.IO.Path.DirectorySeparatorChar + @"customers.db;");
        }
        public virtual DbSet<Kendo.Mvc.Examples.Models.Grid.Customer> Customers { get; set; }
    }
}
