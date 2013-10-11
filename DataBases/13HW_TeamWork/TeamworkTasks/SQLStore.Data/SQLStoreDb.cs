﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLStore.Model;

namespace SQLStore.Data
{
    public class SQLStoreDb : DbContext
    {
        public SQLStoreDb()
            : base("SupermarketDb")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDate> SalesDate { get; set; }
    }
}
