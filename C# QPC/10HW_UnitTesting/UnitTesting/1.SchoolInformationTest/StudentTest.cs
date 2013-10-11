using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1.SchoolInformation;

namespace _1.SchoolInformationTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentNameTest()
        {
            Student stud = new Student("SampleStudent", 50000);
            Assert.AreEqual(stud.Name, "SampleStudent", "Student name is incorrect!");
        }

        [TestMethod]
        public void StudentUniqueNumberLowBoundaryTest()
        {
            Student stud = new Student("SampleStudent", 10000);
            Assert.AreEqual(stud.UniqueNumber, (uint)10000, "Unique number (low boundary) is incorrect!");
        }

        [TestMethod]
        public void StudentUniqueNumberHighBoundaryTest()
        {
            Student stud = new Student("SampleStudent", 99999);
            Assert.AreEqual(stud.UniqueNumber, (uint)99999, "Unique number (high boundary) is incorrect!");
        }

        [TestMethod]
        public void StudentToStringTest()
        {
            Student stud = new Student("SampleStudent", 60000);
            string expected = string.Format("Name: {0}, uniqueNumber: {1}", stud.Name, stud.UniqueNumber);
            Assert.AreEqual(
                stud.ToString(), 
                expected,
                "Student ToString() doesn't work correctly!");
        }
    }
}
