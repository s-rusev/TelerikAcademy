using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentComparison
{
    class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public Student()
        {
            this.firstName = "No first name";
            this.lastName = "No last name";
        }
        public Student(string firstName, string lastName, int age) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        public override string ToString()
        {
            return string.Format("firstName: {0}, lastName: {1}, age: {2}", firstName, lastName, age);
        }

    }
}
