using StudentSystem.Model;
using StudentSystem.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace StudentSystem.Context
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystem")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}