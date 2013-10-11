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
    public class StudentsControllerTest
    {
        [TestMethod]
        public void TestGetAll()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student{FirstName="Test1",LastName="Test1"});
            students.Add(new Student{FirstName="Test2",LastName="Test2"});
            var repository = Mock.Create<IRepository<Student>>();
            Mock.Arrange(() => repository.All())
                .Returns(() => students.AsQueryable());

            StudentsController controller = new StudentsController(repository);
            var result = controller.GetStudents();

            Assert.AreEqual(2,result.Count());
        }

        [TestMethod]
        public void TestGetById()
        {
            var school = new School { Id = 1, Name = "Test" };
            var marks = new List<Mark>();
            var student = new Student { Id = 2, FirstName = "Test1", LastName = "Test1" };
            student.School = school;
            student.Marks = marks;

            var repository = Mock.Create<IRepository<Student>>();
            Mock.Arrange(() => repository.Get(2))
                .Returns(() => student);

            StudentsController controller = new StudentsController(repository);
            var result = controller.GetStudent(2);

            Assert.AreEqual(2, result.Id);
        }

        [TestMethod]
        public void TestPost()
        {
            var school = new School { Id = 1, Name = "Test" };
            var marks = new List<Mark>();
            var student = new Student { Id = 2, FirstName = "Test1", LastName = "Test1" };
            student.School = school;
            student.Marks = marks;

            var repository = Mock.Create<IRepository<Student>>();
            Mock.Arrange(() => repository.Add(student))
                .Returns(() => student);

            StudentsController controller = new StudentsController(repository);
            SetupController(controller);
            var result = controller.PostStudent(student);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post,
                               "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(name: "DefaultApi",
                                   routeTemplate: "api/{controller}/{id}");
            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new
                      HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[
                 HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[
                 HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }
    }
}
