﻿using StudentsDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public StudentModel(Student student)
        {
            this.Id = student.Id;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.Age = student.Age == null ? 0 : (int)student.Age;
            this.Grade = student.Grade == null ? 0 : (int)student.Grade;
        }
    }
}