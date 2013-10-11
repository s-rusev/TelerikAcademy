using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHierarchy
{
    class AnimalTest
    {
        static void Main()
        {
            Cat kittyCat = new Kitten(5, "Kitty");
            Cat kittyCat2 = new Kitten(6, "Mitty");
            //Console.WriteLine(kittyCat.Sex); //demonstrating that the sex property of kitten can be only Female
            Cat tommyCat = new Tomcat(6, "Tommy");
            //Console.WriteLine(tommyCat.Sex); //for tomcat it can only be Male
            Animal sharo = new Dog(5, "Sharo", Sex.Male);
            Animal mustafa = new Dog(8, "Mustafa", Sex.Male);
            Animal kermit = new Frog(1, "Kermit", Sex.Male);
            Animal[] animals = { kittyCat, kittyCat2, tommyCat, sharo, kermit, mustafa };
            foreach (Animal animal in animals)
            {
                animal.ProduceSound();
            }

            var kittensAge =
                from animal in animals
                where animal.GetType() == typeof(Kitten)
                select animal.Age;
            Console.WriteLine("Kittens average age: " + CalculateAverageAge(kittensAge));
            var tomcatsAge =
                from animal in animals
                where animal.GetType() == typeof(Tomcat)
                select animal.Age;
            Console.WriteLine("Tomcats average age: " + CalculateAverageAge(tomcatsAge));
            var dogsAge =
                from animal in animals
                where animal.GetType() == typeof(Dog)
                select animal.Age;
            Console.WriteLine("Dogs average age: " + CalculateAverageAge(dogsAge));
            var frogAge =
                from animal in animals
                where animal.GetType() == typeof(Frog)
                select animal.Age;
            Console.WriteLine("Frog average age: " + CalculateAverageAge(frogAge));
        }

        private static double CalculateAverageAge(IEnumerable<ushort> ages)
        {
            double average = 0.0;
            foreach (var age in ages)
            {
                average += age;
            }
            average /= ages.Count();
            return average;
        }
    }
}
