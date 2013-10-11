using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
        public int ProductQuantity { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Order notes must be at most {1} characters!")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Recipient name must be at least {1} characters!")]
        [MaxLength(20, ErrorMessage = "Recipient name must be at most {1} characters!")]
        public string Recipient { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Recipient address must be at least {1} characters!")]
        [MaxLength(50, ErrorMessage = "Recipient address must be at most {1} characters!")]
        public string Address { get; set; }
    }
}