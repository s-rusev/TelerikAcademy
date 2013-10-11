using StudentSystem.Context;
using StudentSystem.Models;
using System;
using System.Data.Entity;

namespace StudentSystem.Client
{
    public class CodeFirstDemo
    {
        static void Main()
        {
            Database.SetInitializer<StudentSystemContext>(null);

            using (var db = new StudentSystemContext())
            {
                db.Students.Add(new Student { Name = "Svetlin", Number = 123});
                db.SaveChanges();

                foreach (var stud in db.Students)
                {
                    Console.WriteLine(stud.Name);
                }
            }
        }
    }
}