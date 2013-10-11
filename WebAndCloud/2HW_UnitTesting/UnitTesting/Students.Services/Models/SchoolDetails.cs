using StudentsDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class SchoolDetails:SchoolModel
    {
        public ICollection<StudentModel> Students { get; set; }

        public SchoolDetails(School school)
            : base(school)
        {
            this.Students = new List<StudentModel>();
            foreach (var student in school.Students)
            {
                this.Students.Add(new StudentModel(student));
            }
        }
    }
}