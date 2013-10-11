using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SchoolInformation
{
    class SchoolInformationDemo
    {
        static void Main()
        {
            Student ivan = new Student("Ivan", 20000);
            //   Student ivan2 = new Student("Ivan2", 20000); //will break -> number is not unique
            Student dragan = new Student("Dragan", 25000);
            Student petkan = new Student("Petkan", 30000);
            Student lazar = new Student("Lazar", 35000);
            HashSet<Student> studentsMaths = new HashSet<Student>() { ivan, dragan };
            HashSet<Student> studentsBiology = new HashSet<Student>() { petkan, lazar };
            HashSet<Course> courses = new HashSet<Course>() { 
                new Course("Maths", studentsMaths) ,
                new Course("Biology", studentsBiology)
            };

            School school = new School(courses);
            Console.WriteLine(school.ToString());
        }
    }
}
