using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentComparison
{
    class StudentSortTest
    {
        static void Main()
        {
            Student ivan = new Student("Ivan", "Ivanov", 21);
            Student dragan = new Student("Dragan", "Draganov", 22);
            Student petkan = new Student("Petkan", "Daskalov",34);
            Student ivan2 = new Student("Ivan", "Aleksandrov", 31);
            Student[] students = { ivan, dragan, petkan , ivan2};

            //LINQ for selecting all students from array of students
            //whos first name is before their last name
            var studentsFirstNameBeforeLast = 
                from student in students
                where (student.FirstName.CompareTo(student.LastName) == -1)
                select student;
            Console.WriteLine("The students with first name before last name alphabetically are:");
            foreach (Student student in studentsFirstNameBeforeLast)
            {
                Console.WriteLine(student.ToString());
            }

            //LINQ that finds all students with age between 18 and 24
            var studentsWithAge18To24 =
                from student in students
                where (student.Age >= 18 && student.Age <= 24)
                select student;
            Console.WriteLine("All students with age between 18 and 24 are: ");
            foreach (Student student in studentsWithAge18To24)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("Ordered by first and then last name(descending) students:");
            var result = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
            foreach (Student student in result)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
