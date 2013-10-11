using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Store.Models;

namespace Store.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        [Display(Name = "In Stock")]
        public int Stock { get; set; }

        public List<string> PhotosUrlList { get; set; }

        public double? Discount { get; set; }

        public string Category { get; set; }

        [Display(Name = "Total Cost")]
        public double TotalCost
        {
            get
            {
                if (this.Discount != null)
                {
                    return this.Price - ((double)(this.Discount * this.Price));
                }
                else
                {
                    return this.Price;
                }
            }
        }

        public static Expression<Func<Product, ProductViewModel>> FromProduct
        {
            get
            {
                return x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Discount = x.Discount,
                    Price = x.Price,
                    Stock = x.Stock,
                    Category = x.Category.Name
                };
            }
        }
    }
}