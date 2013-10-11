﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStore.Model
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int LocationID { get; set; }
        public int SaleDateID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }

        [ForeignKey("SaleDateID")]
        public virtual SaleDate SaleDate { get; set; }
    }
}
