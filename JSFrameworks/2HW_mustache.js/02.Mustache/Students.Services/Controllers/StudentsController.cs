using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private IEnumerable<Student> students;

        public StudentsController()
        {
            this.students = new List<Student>()
                            {
                                new Student()
                                {
                                    Age = 21,
                                    FirstName = "Pesho",
                                    LastName = "Peshev",
                                    Marks =
                                        new List<Mark>()
                                        {
                                            new Mark(){Score = 6,Subject ="MVC"},
                                            new Mark(){Score = 5,Subject ="C#"},
                                            new Mark(){Score = 2,Subject ="CSS"}
                                        }
                                }, new Student()
                                {
                                    Age = 22,
                                    FirstName = "Dancho",
                                    LastName = "Danchev",
                                    Marks = new List<Mark>()
                                        {
                                            new Mark(){Score = 4,Subject ="HTML"},
                                            new Mark(){Score = 2,Subject ="C#"}
                                        }
                                }, new Student()
                                {
                                    Age = 22,
                                    FirstName = "Kancho",
                                    LastName = "Kanchev",
                                    Marks = new List<Mark>()
                                        {
                                            new Mark(){Score = 4,Subject ="WebForms"},
                                            new Mark(){Score = 5,Subject ="C++"}
                                        }
                                }
                            };
        }

        public HttpResponseMessage GetAllStudents()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK, this.students);
            return response;
        }
    }
}
