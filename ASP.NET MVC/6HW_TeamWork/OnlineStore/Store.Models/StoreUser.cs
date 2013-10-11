using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Store.Models
{
    public class StoreUser : User
    {
        public StoreUser()
        {
            this.Orders = new HashSet<Order>();
        }

        [Required(ErrorMessage = "User email address is required!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}",
            ErrorMessage = "The input is not a valid email address!")]
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
