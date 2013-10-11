using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SchoolInformation
{
    public class Course
    {
        private string name;
        private HashSet<Student> students;

        public Course(string courseName, HashSet<Student> students)
        {
            this.Name = courseName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course name cannot be null!");
                }
                if (value == String.Empty)
                {
                    throw new ArgumentException("Course name cannot be empty!");
                }
                this.name = value;
            }
        }

        public HashSet<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot insert non-existing student!");
                }
                this.students = value;
            }
        }

        public void AddStudent(Student studentToAdd)
        {
            if (this.students.Count > 30)
            {
                throw new InvalidOperationException("Cannot add student in course! Course has maximum 30 students.");
            }
            this.Students.Add(studentToAdd);
        }

        public void RemoveStudents(Student studentToRemove) 
        {
            if (this.students.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove student from emptry course");
            }
            this.students.Remove(studentToRemove);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.name + '\n');
            foreach (var student in students)
            {
                result.Append(student.ToString() + '\n');
            }

            return result.ToString();
        }
    }
}
