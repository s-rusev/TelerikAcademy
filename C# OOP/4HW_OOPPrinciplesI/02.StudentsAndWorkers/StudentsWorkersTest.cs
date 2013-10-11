using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{
    class StudentsWorkersTest
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int nameIndex = rand.Next(50);
                string firstName = "Student" + nameIndex;
                string lastName = "Studentov" + (50 - nameIndex);
                students.Add(new Student(firstName, lastName, rand.Next(2, 7).ToString()));
            }
            Console.WriteLine("Not sorted students:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
            students = students.OrderBy(student => student.Grade).ToList();

            Console.WriteLine("Sorted students by grade:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }

            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < 10; i++)
            {
                int nameIndex = rand.Next(50);
                string firstName = "Worker" + nameIndex;
                string lastName = "Workerov" + (50 - nameIndex);
                decimal salary = (decimal)rand.NextDouble() * 1000;
                ushort workHours = (ushort)rand.Next(50);
                workers.Add(new Worker(salary, workHours, firstName, lastName));
            }
            Console.WriteLine("Not Sorted students:");
            foreach (var worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }
            workers = workers.OrderByDescending(worker => worker.WorkHoursPerDay).ToList();

            Console.WriteLine("Sorted workers by work hours per day:");
            foreach (var worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }

            List<Human> workersAndStudents = new List<Human>();
            foreach (var worker in workers)
            {
                workersAndStudents.Add(worker);
            }
            foreach (var student in students)
            {
                workersAndStudents.Add(student);
            }
            workersAndStudents = workersAndStudents.OrderBy(entry => entry.FirstName).ThenBy(entry => entry.LastName).ToList();
            Console.WriteLine("Sorted students and workers by first and last name:");
            foreach (var workerOrStudent in  workersAndStudents)
            {
                Console.WriteLine(workerOrStudent.ToString());
            }
        }
    }
}
