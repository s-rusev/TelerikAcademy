using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SchoolInformation
{
    public class School
    {
        private HashSet<Course> courses = new HashSet<Course>();
        public static HashSet<uint> StudentNumbers = new HashSet<uint>();

        public School(HashSet<Course> courses)
        {
            this.Courses = courses;
        }

        public HashSet<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var course in courses)
            {
                result.Append(course.ToString());
            }

            return result.ToString();
        }
    }
}
