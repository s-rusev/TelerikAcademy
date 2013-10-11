using System;
using System.Collections.Generic;

namespace Students.Service.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Grade { get; set; }

        public List<Mark> Marks { get; set; }

        public Student()
        {
            this.Marks = new List<Mark>();
        }
    }
}