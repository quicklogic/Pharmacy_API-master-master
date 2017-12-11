using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PharmacyAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=Pharmacy")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
    }
}