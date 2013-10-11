using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAverageSequence
{
    public class SumAverageSequenceDemo
    {
        public static void Main()
        {
            Console.WriteLine("Enter positive numbers and empty line to end sequence.");
            List<int> sequenceNumbers = ProcessInput();
            Console.WriteLine("Average is: {0:F2}", sequenceNumbers.Average());
            Console.WriteLine("Sum is {0}", sequenceNumbers.Sum());
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
                    if (number < 0)
                    {
                        Console.WriteLine("Number must be positive!");
                    }
                    else
                    {
                        sequenceNumbers.Add(number);
                    }
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
