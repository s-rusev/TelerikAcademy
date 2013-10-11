using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;

namespace Store.Data
{
    public class StoreDataContext : IdentityDbContextWithCustomUser<StoreUser>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderedProduct> OrderedProducts { get; set; }
    }
}
