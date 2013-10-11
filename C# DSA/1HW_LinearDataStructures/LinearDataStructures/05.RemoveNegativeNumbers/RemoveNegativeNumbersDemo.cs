using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativeNumbers
{
    public class RemoveNegativeNumbersDemo
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers and empty line to end sequence.");
            List<int> sequenceNumbers = ProcessInput();
            sequenceNumbers.RemoveAll(x => x < 0);

            Console.WriteLine("All non-negative numbers are:");
            foreach (var number in sequenceNumbers)
            {
                Console.WriteLine(number);
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
