using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketCreateViewModel
    {
        public int CategoryId{ get; set; }

        public Priority Priority { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [ShouldNotContainBug("bug", ErrorMessage="The word 'bug' should not be in the title!")]
        
        public string Title { get; set; }
    }
}