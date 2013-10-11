using StudentsDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class MarkModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Value { get; set; }

        public MarkModel(Mark mark)
        {
            this.Id = mark.Id;
            this.Subject = mark.Subject.Name;
            this.Value = mark.Value;
        }
    }
}