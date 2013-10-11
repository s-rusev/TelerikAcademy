using Store.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentCategory = x.Parent.Name,
                    ProductsCount = x.Products.Count
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public string ParentCategory { get; set; }

        [Display(Name = "Products Count")]
        public int ProductsCount { get; set; }
    }
}