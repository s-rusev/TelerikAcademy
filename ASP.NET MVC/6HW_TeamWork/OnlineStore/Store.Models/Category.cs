using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required!")]
        [MaxLength(50, ErrorMessage = "Category name must be at most {1} characters!")]
        [MinLength(3, ErrorMessage = "Category name must be at least {1} characters!")]
        public string Name { get; set; }

        public virtual Category Parent { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
