using StudentsDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class MarkDetails:MarkModel
    {
        public StudentModel Student { get; set; }

        public MarkDetails(Mark mark)
            : base(mark)
        {
            this.Student = new StudentModel(mark.Student);
        }
    }
}