using Store.Models;
using Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Utilities
{
    public static class ConvertToViewModels
    {
        public static IQueryable<ProductViewModel> ConvertToProductsViewModel(this IQueryable<Product> Products)
        {
            List<int> a = new List<int>();

            return Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Discount = p.Discount.HasValue ? p.Discount.Value : 0,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category.Name
            });
        }
    }
}