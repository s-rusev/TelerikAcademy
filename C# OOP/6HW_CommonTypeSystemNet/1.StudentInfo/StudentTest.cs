using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StudentInfo
{
    class StudentTest
    {
        static void Main()
        {
            Student ivan1 = new Student("Ivan", "Ivanov", "Ivanov", 12345, "Peichinovo", 
                "0888888888", "ivan@gmail.com", 3, Speciality.Mathematics, University.Oxford, Faculty.Mathematics);
            Console.WriteLine(ivan1.ToString());
            Student ivan2 = new Student("Ivan", "Ivanov", "Ivanov", 12345, "Peichinovo",
                "0888888888", "ivan@gmail.com", 3, Speciality.Mathematics, University.Oxford, Faculty.Mathematics);
            Student dragan = new Student("Dragan", "Draganov", "Draganov", 123456, "Ivanovo",
                "0888888888", "dragan@gmail.com", 5, Speciality.Mathematics, University.Oxford, Faculty.Mathematics);
            Student draganWithGreaterSsn = new Student("Dragan", "Draganov", "Draganov", 1234567, "Ivanovo",
                "0888888888", "dragan@gmail.com", 5, Speciality.Mathematics, University.Oxford, Faculty.Mathematics);
            Console.WriteLine("Is ivan1 the same entry as ivan2: " + ivan1.Equals(ivan2)); // must be true :)
            Console.WriteLine("Are ivan1 and dragan different: " + (dragan != ivan1)); // must be true too
            Console.WriteLine(ivan1.GetHashCode());
            //Console.WriteLine(ivan2.GetHashCode());
            Student ivanClone = ivan1.Clone();
            Console.WriteLine("Ivan clone:");
            Console.WriteLine(ivanClone.ToString());
            Console.WriteLine("dragan.CompareTo(ivan1): " + dragan.CompareTo(ivan1)); // must be negative number because instance preceeds value
            Console.WriteLine("dragan.CompareTo(dragan): " + dragan.CompareTo(dragan)); //guess what 
            Console.WriteLine("dragan.CompareTo(draganGreaterSSN): " + dragan.CompareTo(draganWithGreaterSsn)); // positive because value preceeds instance
        }
    }
}
