using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SchoolHierarchy
{
    class SchoolTest
    {
        //demonstrating most of the class hierarchy
        static void Main()
        {
            List<Disciplines> disciplines = new List<Disciplines>();
            Disciplines d1 = new Disciplines("Maths", 20, 20);
            //d1.AddComment("Discipline comment");
            Disciplines d2 = new Disciplines("Physics", 30, 30);
            disciplines.Add(d1);
            disciplines.Add(d2);
            List<Teacher> teachers = new List<Teacher>();
            Teacher t1 = new Teacher("Chaparov", disciplines);
            //t1.AddComment("Teacher comment");
            Teacher t2 = new Teacher("Kostadinova", disciplines);
            //  Console.WriteLine(t1.ToString()); //for teachers toString
            teachers.Add(t1);
            teachers.Add(t2);

            List<Student> students = new List<Student>();
            Student ivan = new Student("Ivan", 123);
            Student dragan = new Student("Dragan", 1245);
            students.Add(ivan);
            students.Add(dragan);

            StudentClass class1 = new StudentClass(students, teachers, "10A");

            //class1.AddComment("Class comment");
            //Console.WriteLine(class1.ToString());
            List<StudentClass> studentClasses = new List<StudentClass>();
            School mgBabaTonka = new School(studentClasses); //studentClasses doesn't contain any classes now
            Console.WriteLine(mgBabaTonka.ToString());
            Console.WriteLine("Adding class to the school:");
            studentClasses.Add(class1);
            Console.WriteLine(mgBabaTonka.ToString());

            //To demonstrate students uncomment this lines
            //ivan.AddComment("Sample comment");
            //ivan.AddComment("Another comment");
            //foreach (var comment in ivan.Comments)
            //{
            //    Console.WriteLine(comment);
            //}
            // Console.WriteLine(ivan.ToString());
            //  Student dragan = new Student("Dragan", 123); //will brake because student number must be unique
        }
    }
}
