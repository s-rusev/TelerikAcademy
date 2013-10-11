using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MostFrequentElement
{
    public class MostFrequentElementDemo
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers and empty line to end sequence.");
            List<int> numbers = ProcessInput();

            var query = (from item in numbers
                         group item by item into numberCount
                         orderby numberCount.Count() descending
                         select new { Number = numberCount.Key, Count = numberCount.Count() }).First();

            if (query.Count >= numbers.Count + 1)
            {
                Console.WriteLine(query.Number);
            }
            else
            {
                Console.WriteLine("No majorant!");
            }
        }

        private static List<int> ProcessInput()
        {
            List<int> sequenceNumbers = new List<int>();
            string inputNumber = Console.ReadLine();

            while (inputNumber != String.Empty)
            {
                int number;
                bool isValidNumber = int.TryParse(inputNumber, out number);
                if (isValidNumber)
                {
                    sequenceNumbers.Add(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }

                inputNumber = Console.ReadLine();
            }

            return sequenceNumbers;
        }
    }
}
