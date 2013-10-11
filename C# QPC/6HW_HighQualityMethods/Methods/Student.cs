namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string OtherInfo { get; set; }

        public Student(string firstName, string lastName, DateTime birthDay, string otherInfo = null) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.OtherInfo = otherInfo;
        }

        public bool IsOlderThan(Student otherStudent)
        {
            bool isOlder = false;
            DateTime firstStudentBirthDay = this.BirthDay;
            DateTime secondStudentBirthDay = otherStudent.BirthDay;

            if (firstStudentBirthDay.CompareTo(secondStudentBirthDay) < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }
}