using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace _1.CoursesAndStudents
{
    public class StudentCoursesDemo
    {
        public static void Main()
        {
            string path = "..//..//students.txt";
            string[] lines = GetLinesFromTextFile(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            OrderedMultiDictionary<string, Student> coursesStudents =
                new OrderedMultiDictionary<string, Student>(true); 
            coursesStudents = GetCoursesAndStudents(lines);

            foreach (var courseStudents in coursesStudents)
            {
                Console.WriteLine(courseStudents.Key+"->");
                foreach (var stud in courseStudents.Value)
                {
                    Console.WriteLine("..." + stud.ToString());
                }
            }
        }

        private static OrderedMultiDictionary<string, Student> GetCoursesAndStudents(string[] lines)
        {
            OrderedMultiDictionary<string, Student> coursesStudents =
                new OrderedMultiDictionary<string, Student>(true);
            foreach (var line in lines)
            {
                string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0].Trim();
                string lastName = tokens[1].Trim();
                string course = tokens[2].Trim();
                if (coursesStudents.ContainsKey(course))
                {
                    coursesStudents[course].Add(new Student(firstName, lastName));
                }
                else
                {
                    coursesStudents[course] = new SortedSet<Student>();
                    coursesStudents[course].Add(new Student(firstName, lastName));
                }
            }

            return coursesStudents;
        }

        private static string[] GetLinesFromTextFile(string path)
        {
            string[] lines = null;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadToEnd();
                    char[] seperators = new char[] { '\r', '\n' };
                    lines = text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return lines;
        }
    }
}
