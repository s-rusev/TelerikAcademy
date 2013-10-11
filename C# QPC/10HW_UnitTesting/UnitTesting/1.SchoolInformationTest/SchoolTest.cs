using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1.SchoolInformation;
using System.Collections.Generic;

namespace _1.SchoolInformationTest
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolCourseTest()
        {
            Student lazar = new Student("Lazar", 35163);
            HashSet<Student> students = new HashSet<Student>() { lazar };
            Course course = new Course("SampleCourse", students);
            HashSet<Course> courses = new HashSet<Course>() { course };
            School school = new School(courses);
            string expected = course.ToString();

            Assert.AreEqual(expected, school.ToString(), "Course name is incorrect!");
        }
    }
}
