using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SortList
{
    public class SortListDemo
    {
        static void Main()
        {
            List<int> sequenceNumbers = ProcessInput();
            sequenceNumbers.Sort();
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
