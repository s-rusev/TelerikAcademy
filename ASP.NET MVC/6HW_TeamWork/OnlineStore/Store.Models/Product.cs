using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required!")]
        [MinLength(5, ErrorMessage = "Porduct name must be at least {1} characters!")]
        [MaxLength(50, ErrorMessage = "Product name must be at most {1} characters!")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Product description is required!")]
        [MinLength(30, ErrorMessage = "Porduct description must be at least {1} characters!")]
        [MaxLength(500, ErrorMessage = "Product description must be at most {1} characters!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required!")]
        [Range(0.1D, Double.MaxValue, ErrorMessage = "Product price must be in the range [{1}, {2}]!")]
        [DisplayFormat(DataFormatString = "{0:0.00 lv.}")]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Units in stock must be in the range [{1}, {2}]!")]
        public int Stock { get; set; }

        public string PhotosFolderPath { get; set; }

        [Range(0.03, 0.8, ErrorMessage = "Discount percent must be in the range [{1}, {2}]!")]
        [DisplayFormat(DataFormatString="{0:P2}")]
        public double? Discount { get; set; }

        [Display(Name="Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public virtual Category Category { get; set; }
    }
}
