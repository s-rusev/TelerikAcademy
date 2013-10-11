using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1.SchoolInformation;
using System.Collections.Generic;

namespace _1.SchoolInformationTest
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseNameTest()
        {
            Student lazar = new Student("Lazar", 35123);
            HashSet<Student> students = new HashSet<Student>() { lazar };

            Course course = new Course("SampleCourse", students);
            Assert.AreEqual(course.Name, "SampleCourse", "Course name is incorrect!");
        }

        [TestMethod]
        public void AddStudentTest()
        {
            Student ivanToAdd = new Student("IvanToAdd", 54321);
            HashSet<Student> students = new HashSet<Student>() { ivanToAdd };
            Course course = new Course("SampleCourse", students);
            course.AddStudent(ivanToAdd);
            Assert.AreEqual(true, (course.Students.Contains(ivanToAdd)), "Add doesn't work corectly!");
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            Student ivanToRemove = new Student("IvanToRemove", 35523);
            HashSet<Student> students = new HashSet<Student>() { ivanToRemove };
            Course course = new Course("SampleCourse", students);
            course.RemoveStudents(ivanToRemove);
            Assert.AreEqual(false, (course.Students.Contains(ivanToRemove)), "Remove doesn't work corectly!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFromEmptyTest()
        {
            HashSet<Student> students = new HashSet<Student>();
            Course course = new Course("SampleCourse", students);

            course.RemoveStudents(new Student("Georgi", 12345));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddMoreStudentsThanCapacityTest()
        {
            Student petrakii = new Student("Petrakii", 35523);
            HashSet<Student> students = new HashSet<Student>() { petrakii };
            Course course = new Course("SampleCourse", students);

            for (int numberOfStudents = 0; numberOfStudents < 35; numberOfStudents++)
            {
                course.AddStudent(new Student("Mustafa", (uint)(numberOfStudents + 14000)));
            }
        }

        [TestMethod]
        public void CourseToStringTest()
        {
            Student petrakii = new Student("Petrakii", 77777);
            HashSet<Student> students = new HashSet<Student>() { petrakii };
            Course course = new Course("SampleCourse", students);
            string expected = course.Name + '\n' + petrakii.ToString() + '\n';

            Assert.AreEqual(expected, course.ToString(), "Course.ToString() doesn't work correctly!");
        }
    }


}
