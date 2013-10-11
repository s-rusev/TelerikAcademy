using Store.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Areas.Admin.Models
{
    public class UserViewModel
    {
        public static Expression<Func<StoreUser, UserViewModel>> FromUser
        {
            get
            {
                return x => new UserViewModel()
                {
                    Id = x.Id,
                    Username = x.UserName,
                    Email = x.Email,
                    PendingOrders =
                        (from order in x.Orders
                         where order.OrderStatus == OrderStatus.Prending
                         select order).Count(),
                    FinishedOrders =
                        (from order in x.Orders
                         where order.OrderStatus == OrderStatus.Finished
                         select order).Count(),
                    Role =
                        (from role in x.Roles
                         select role.Role.Name).FirstOrDefault()
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [Display(Name = "Pending Orders")]
        public int PendingOrders { get; set; }

        [Display(Name = "Finished Orders")]
        public int FinishedOrders { get; set; }

        public string Role { get; set; }
    }
}