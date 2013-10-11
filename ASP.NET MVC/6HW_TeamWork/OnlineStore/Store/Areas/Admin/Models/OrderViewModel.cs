using Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Store.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public static Expression<Func<Order, OrderViewModel>> FromOrder
        {
            get
            {
                return x => new OrderViewModel()
                {
                    Id = x.Id,
                    User = x.User.UserName,
                    ProductsCount = x.OrderedProducts.Count,
                    Recipient = x.Recipient,
                    Address = x.Address,
                    Notes = x.Notes,
                    Date = x.Date,
                    OrderStatus = x.OrderStatus
                };
            }
        }

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy, HH:mm}")]
        public DateTime Date { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Status")]
        public OrderStatus OrderStatus { get; set; }

        public int ProductsCount { get; set; }

        public string User { get; set; }

        public string Recipient { get; set; }

        public string Address { get; set; }
    }
}