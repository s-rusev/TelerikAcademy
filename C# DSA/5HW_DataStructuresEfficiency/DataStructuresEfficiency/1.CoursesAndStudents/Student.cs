using System;

namespace _1.CoursesAndStudents
{
    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format(FirstName + " " + LastName);
        }

        public int CompareTo(Student second)
        {
            int result = this.LastName.CompareTo(second.LastName);
            if (result == 0)
            {
                result = this.FirstName.CompareTo(second.FirstName);
            }

            return result;
        }
    }
}
