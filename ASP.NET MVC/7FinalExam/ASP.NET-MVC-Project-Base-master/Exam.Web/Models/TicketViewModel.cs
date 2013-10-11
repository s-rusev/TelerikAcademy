using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public int CommentsCount { get; set; }
    }
}