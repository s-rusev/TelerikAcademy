using System;
using System.Collections.Generic;
using System.Text;

namespace _09.QueueSequence
{
    public class QueueSequenceDemo
    {
        static void Main()
        {
            Console.Write("Enter start number N for the sequence: ");
            int firstElement = GetValidNumber();
            int membersCount = (50 / 3) - 1;

            StringBuilder result = new StringBuilder();

            List<int> sequence = new List<int>();
            sequence.Add(firstElement);
            for (int i = 0; i < membersCount; i++)
            {
                sequence.Add(sequence[i] + 1);
                sequence.Add(2 * sequence[i] + 1);
                sequence.Add(sequence[i] + 2);
            }

            foreach (var item in sequence)
            {
                result.Append(item + " ");
            }

            Console.WriteLine(result);
        }

        private static int GetValidNumber()
        {
            int validNumber = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                string input = Console.ReadLine();
                isValidInput = int.TryParse(input, out validNumber);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    isValidInput = true;
                }
            }

            return validNumber;
        }
    }
}