using StudentsDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class StudentDetails : StudentModel
    {
        public ICollection<MarkModel> Marks { get; set; }
        public SchoolModel School { get; set; }

        public StudentDetails(Student student)
            : base(student)
        {
            this.School = new SchoolModel(student.School);
            this.Marks = new List<MarkModel>();
            foreach (var mark in student.Marks)
            {
                this.Marks.Add(new MarkModel(mark));
            }
        }
    }
}