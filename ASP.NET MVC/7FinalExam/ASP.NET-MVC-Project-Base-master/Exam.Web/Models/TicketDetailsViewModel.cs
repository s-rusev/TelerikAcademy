using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        //public IEnumerable<CommentViewModel> TicketComments { get; set; }

        public Priority Priority { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}