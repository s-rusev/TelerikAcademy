using System;
using System.Linq;
using System.Diagnostics;
using System.Collections;

namespace _1_2.TelerikAcademyEmployees
{
    class Program
    {
        static void Main()
        {
            TelerikAcademyEntities db = new TelerikAcademyEntities();

            foreach (var e in db.Employees)
            {
                Console.WriteLine("Product: {0}, {1}, {2};", e.FirstName, e.Department.Name, e.Address.Town.Name);
            }

            foreach (var e in db.Employees.Include("Address"))
            {
                Console.WriteLine("Product: {0}, {1}, {2};", e.FirstName, e.Department.Name, e.Address.Town.Name);
            }
 
            //2nd task

            IEnumerable query = db.Employees.ToList()
                .Select(x => x.Address).ToList()
                .Select(t => t.Town).ToList()
                .Where(t => t.Name == "Sofia");

            IEnumerable querySmart = db.Employees
               .Select(x => x.Address)
               .Select(t => t.Town)
               .Where(t => t.Name == "Sofia").ToList();

        }
    }
}