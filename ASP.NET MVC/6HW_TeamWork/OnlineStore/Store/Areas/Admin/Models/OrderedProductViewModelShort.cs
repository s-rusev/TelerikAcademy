using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Store.Areas.Admin.Models
{
    public class OrderedProductViewModelShort
    {
        public static Expression<Func<OrderedProduct, OrderedProductViewModelShort>> FromOrderedProduct
        {
            get
            {
                return x => new OrderedProductViewModelShort()
                {
                    Id = x.Id,
                    Name = x.Product.Name,
                    Count = x.Count
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}