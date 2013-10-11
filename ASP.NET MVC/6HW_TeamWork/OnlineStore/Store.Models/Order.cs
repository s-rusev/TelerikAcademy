using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderedProducts = new HashSet<OrderedProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order date is required!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy, HH:mm}")]
        public DateTime Date { get; set; }

        [MaxLength(500, ErrorMessage = "Order notes must be at most {1} characters!")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Order status is required!")]
        [Display(Name = "Status")]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        [Display(Name="User")]
        public string UserId { get; set; }

        public virtual StoreUser User { get; set; }

        //[CollectionCount(50, ErrorMessage = "You can order at most {1} different products!")]
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }

        [MinLength(5, ErrorMessage = "Recipient name must be at least {1} characters!")]
        [MaxLength(20, ErrorMessage = "Recipient name must be at most {1} characters!")]
        public string Recipient { get; set; }

        [MinLength(10, ErrorMessage = "Recipient address must be at least {1} characters!")]
        [MaxLength(50, ErrorMessage = "Recipient address must be at most {1} characters!")]
        public string Address { get; set; }
    }
}
