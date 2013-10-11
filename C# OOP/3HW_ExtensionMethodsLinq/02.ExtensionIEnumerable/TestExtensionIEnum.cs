using System;
using System.Collections.Generic;

namespace _02.ExtensionIEnumerable
{
    class TestExtensionIEnum
    {
        static void Main()
        {
            int[] integers = { 2, 3, 4, 62, -2, 412, 42, 7 };
            double[] doubles = { 2.5, 4, 5.2, -2, 1.7 };
            List<int> listInts = new List<int>(integers);
            List<double> listDoubles = new List<double>(doubles);

            Console.WriteLine("Demonstrating operations for integers: ");
            Console.WriteLine("Sum: " + listInts.Sum());
            Console.WriteLine("Product: " + listInts.Product());
            Console.WriteLine("Max element: " + listInts.Max());
            Console.WriteLine("Min element: " + listInts.Min());
            Console.WriteLine("Average: " + listInts.Average());

            Console.WriteLine("Demonstrating operations for doubles: ");
            Console.WriteLine("Sum: " + listDoubles.Sum());
            Console.WriteLine("Product: " + listDoubles.Product());
            Console.WriteLine("Max element: " + listDoubles.Max());
            Console.WriteLine("Min element: " + listDoubles.Min());
            Console.WriteLine("Average: " + listDoubles.Average());


        }
    }

}
