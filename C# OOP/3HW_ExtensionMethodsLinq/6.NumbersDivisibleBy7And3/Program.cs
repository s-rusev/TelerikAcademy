using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.NumbersDivisibleBy7And3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 21, 42, 15, 14, 3, 1, -2 };
            //min, max -> stack overflow?
            //.where makes IEnumerable and returns where match is found
            //yield -> something like breakpoint, works with copy of execution stack?

            var numbersDivisibleBy7And3 = arr.Where(
                x => ((x % 3 == 0) && (x % 7 == 0)) == true);
            foreach (var num in numbersDivisibleBy7And3)
            {
                Console.WriteLine(num);
            }

            var numbersDivisibleBy7And3Linq =
                from num in arr
                where ((num % 7 == 0) && (num % 3 == 0))
                select num;
            foreach (var num in numbersDivisibleBy7And3Linq)
            {
                Console.WriteLine(num);
            }
        }
    }
}
