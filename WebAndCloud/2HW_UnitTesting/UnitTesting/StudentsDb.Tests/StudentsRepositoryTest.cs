using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.Model;
using System.Transactions;
using System.Data;
using Repositories;

namespace StudentsDb.Tests
{
    [TestClass]
    public class StudentsRepositoryTest
    {
        static StudentsDbEntities context = new StudentsDbEntities();
        static IRepository<Student> repository = new Repository<Student>(context);
        TransactionScope tran;

        [TestInitialize]
        public void StartTransaction()
        {
            repository = new Repository<Student>(context);
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void CloseTransaction()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void TestDeleteWithValidStudent()
        {
            Student student = new Student
            {
                FirstName = "Test1",
                LastName = "Test1",
            };

            var addedStudent = context.Students.Add(student);
            context.SaveChanges();
            int id = addedStudent.Id;
            repository.Delete(id);
            var removedStudent = context.Students.Find(id);
            Assert.IsNull(removedStudent);
        }

        [TestMethod]
        public void TestAddWithValidStudent()
        {
            Student student = new Student
            {
                FirstName = "Test",
                LastName = "Test",
            };

            var addedStudent = repository.Add(student);
            Assert.IsTrue(addedStudent.Id > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void TestAddWithInvalidStudent()
        {
            Student student = new Student
            {
                FirstName = "Test"
            };

            var addedStudent = repository.Add(student);
        }
    }
}
