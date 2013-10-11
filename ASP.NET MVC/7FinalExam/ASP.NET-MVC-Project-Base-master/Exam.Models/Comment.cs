using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
        
        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string Content { get; set; }
    }
}
