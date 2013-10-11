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
    public class SchoolsController : ApiController
    {
        private IRepository<School> repository;

        public SchoolsController()
        {
            var dbContext = new StudentsDbEntities();
            this.repository = new Repository<School>(dbContext);
        }

        [HttpGet]
        public IEnumerable<SchoolModel> GetStudents()
        {
            var schools = this.repository.All();
            var schoolsModels = new List<SchoolModel>();
            foreach (var school in schools)
            {
                schoolsModels.Add(new SchoolModel(school));
            }

            return schoolsModels;
        }

        [HttpGet]
        public SchoolDetails GetStudent(int id)
        {
            var school = this.repository.Get(id);
            var schoolDetails = new SchoolDetails(school);
            return schoolDetails;
        }

        [HttpPost]
        public HttpResponseMessage PostStudent(School school)
        {
            this.repository.Add(school);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
