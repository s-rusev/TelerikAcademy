using System;

namespace _1.StudentInfo
{
    class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private uint socialSecurityNumber; //SSN
        private string address;
        private string mobilePhone;
        private string eMail;
        private byte course;
        private Speciality speciality;
        private University university;
        private Faculty faculty;

        public Student(string firstName, string middleName, string lastName,
            uint ssn, string address, string mobilePhone, string eMail, byte course,
            Speciality speciality, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecurityNumber = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.EMail = eMail;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }


        #region properties

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public uint SocialSecurityNumber
        {
            get
            {
                return this.socialSecurityNumber;
            }
            set
            {
                this.socialSecurityNumber = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                this.mobilePhone = value;
            }
        }

        public string EMail
        {
            get
            {
                return this.eMail;
            }
            set
            {
                this.eMail = value;
            }
        }

        public byte Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }

        public Speciality Speciality
        {
            get
            {
                return this.speciality;
            }
            set
            {
                this.speciality = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }
            set
            {
                this.university = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            set
            {
                this.faculty = value;
            }
        }
        #endregion

        #region methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (this.firstName != student.firstName
                || this.middleName != student.middleName
                || this.lastName != student.lastName
                || this.socialSecurityNumber != student.socialSecurityNumber
                || this.address != student.address
                || this.mobilePhone != student.mobilePhone
                || this.eMail != student.eMail
                || this.course != student.course
                || this.speciality != student.speciality
                || this.university != student.university
                || this.faculty != student.faculty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(Equals(firstStudent, secondStudent));
        }

        public Student Clone()
        {
            return
                 new Student(this.firstName, this.middleName, this.lastName,
                 this.socialSecurityNumber, this.address, this.mobilePhone,
                 this.eMail, this.course, this.speciality, this.university,
                 this.faculty);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public override int GetHashCode()
        {
            return
                (this.firstName.GetHashCode() * 397) ^ (this.middleName.GetHashCode() + 41)
                ^ this.lastName.GetHashCode();
        }


        public int CompareTo(Student secondStudent)
        {
            if ((this.firstName.Equals(secondStudent.firstName)) &&
                (this.middleName.Equals(secondStudent.middleName)) &&
                (this.lastName.Equals(secondStudent.lastName)))
            {
                return secondStudent.socialSecurityNumber.CompareTo(this.socialSecurityNumber);
            }
            else //if names are different
            {
                string firstStudentName = this.firstName + this.middleName + this.lastName;
                string secondStudentName = secondStudent.firstName + secondStudent.middleName + secondStudent.lastName;
                return (firstStudentName.CompareTo(secondStudentName));
            }
        }

        public override string ToString()
        {
            return string.Format("Student: {0} {1} {2} with SSN: {3}; \nAddress: {4} \n" +
                "Mobile phone: {5} \nE-mail: {6} \nCourse: {7}, Speciality: {8}, University: {9}, Faculty: {10}",
                firstName, middleName, lastName, socialSecurityNumber, address,
                mobilePhone, eMail, course, speciality, university, faculty);
        }
        #endregion
    }
}
