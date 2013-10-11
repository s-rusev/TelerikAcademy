using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class SubmitCommentModel
    {
        [Required]
        //should not contain bug
        public string Comment { get; set; }

        [Required]
        public int TicketId { get; set; }
    }
}