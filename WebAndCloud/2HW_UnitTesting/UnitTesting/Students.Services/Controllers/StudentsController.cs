using Repositories;
using Students.Services.Models;
using StudentsDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> repository;

        public StudentsController()
        {
            var dbContext = new StudentsDbEntities();
            this.repository = new Repository<Student>(dbContext);
        }

        public StudentsController(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<StudentModel> GetStudents()
        {
            var students= this.repository.All();
            var studentsModels = new List<StudentModel>();
            foreach (var student in students)
            {
                studentsModels.Add(new StudentModel(student));
            }

            return studentsModels;
        }

        [HttpGet]
        public StudentDetails GetStudent(int id)
        {
            var student = this.repository.Get(id);
            var studentDetails = new StudentDetails(student);
            return studentDetails;
        }

        [HttpPost]
        public HttpResponseMessage PostStudent(Student student)
        {
            this.repository.Add(student);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
