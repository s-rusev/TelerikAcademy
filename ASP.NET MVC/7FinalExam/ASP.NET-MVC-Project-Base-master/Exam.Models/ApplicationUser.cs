using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ApplicationUser : User
    {
        private const int StartPointsUser = 10;

        public ApplicationUser()
            : base()
        {
            this.Points = StartPointsUser;
        }

        public int Points { get; set; }
    }
}
