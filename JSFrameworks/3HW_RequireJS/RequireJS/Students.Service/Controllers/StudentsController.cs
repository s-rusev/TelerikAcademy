using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Service.Models;

namespace Students.Service.Controllers
{
    public class StudentsController : ApiController
    {
        private static List<Student> Students = GenerateStudents();

        [HttpGet]
        public List<Student> GetAll()
        {
            return Students;
        }

        [HttpGet]
        [ActionName("marks")]
        public List<Mark> GetMarks(int studentId)
        {
            var student = Students[studentId - 1];

            return student.Marks;
        }

        private static List<Student> GenerateStudents()
        {
            List<Student> students = new List<Student>();

            Student pesho = new Student()
            {
                Grade = 2,
                Name = "Pesho Peshov",
                StudentId = 1
            };

            for (int i = 2; i <= 6; i++)
            {
                pesho.Marks.Add(new Mark()
                {
                    Score = i,
                    Subject = "Subject #" + (i - 1).ToString(),
                    StudentName = "Pesho"
                }
                );
            }

            Student gosho = new Student()
            {
                Grade = 2,
                Name = "Gosho Goshov",
                StudentId = 2
            };

            for (int i = 3; i <= 5; i++)
            {
                gosho.Marks.Add(new Mark()
                {
                    Score = i,
                    Subject = "Subject #" + (i - 2).ToString(),
                    StudentName = "Gosho"
                }
                );
            }

            Student tosho = new Student()
            {
                Grade = 2,
                Name = "Tosho Toshov",
                StudentId = 3
            };

            for (int i = 4; i <= 5; i++)
            {
                tosho.Marks.Add(new Mark()
                {
                    Score = i,
                    Subject = "Subject #" + (i - 3).ToString(),
                    StudentName = "Tosho"
                }
                );
            }

            students.Add(pesho);
            students.Add(gosho);
            students.Add(tosho);

            return students;
        }
    }
}
