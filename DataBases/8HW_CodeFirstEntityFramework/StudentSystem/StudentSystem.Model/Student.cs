using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using StudentSystem.Model;

namespace StudentSystem.Models
{
    [Table("Students")]
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        [Key, Column("StudentId")]
        public int StudentID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Number")]
        public int Number { get; set; }

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

    }
}