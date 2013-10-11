using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Repositories;
using StudentsDb.Model;
using System.Collections.Generic;
using System.Linq;
using Students.Services.Controllers;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;

namespace StudentsDb.Tests
{
    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestMethod]
        public void TestGetAll()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { FirstName = "Test1", LastName = "Test1" });
            students.Add(new Student { FirstName = "Test2", LastName = "Test2" });
            var repository = Mock.Create<IRepository<Student>>();
            Mock.Arrange(() => repository.All())
                .Returns(() => students.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost:1231/api", repository);
            var response = server.CreateGetRequest("/students");


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
