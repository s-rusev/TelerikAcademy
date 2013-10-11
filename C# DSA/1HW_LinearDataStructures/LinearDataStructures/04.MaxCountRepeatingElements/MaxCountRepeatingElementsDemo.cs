using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MaxCountRepeatingElements
{
    class MaxCountRepeatingElementsDemo
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers and empty line to end sequence.");
            List<int> numbers = ProcessInput();
            List<int> longestRepeatingElements = GetMaxRepeatingElement(numbers);

            Console.WriteLine("The longest sequence is: ");
            foreach (var item in longestRepeatingElements)
            {
                Console.WriteLine(item);
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

        private static List<int> GetMaxRepeatingElement(List<int> numbers)
        {
            int currentMaxSequenceLength = 0;
            int maxSequenceLength = 1;
            int startIndexSequence = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                currentMaxSequenceLength = 1;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentMaxSequenceLength++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentMaxSequenceLength > maxSequenceLength)
                {
                    startIndexSequence = i;
                    maxSequenceLength = currentMaxSequenceLength;
                }
            }

            List<int> maxRepeatingSequence = new List<int>();
            for (int i = 0; i < maxSequenceLength; i++)
            {
                maxRepeatingSequence.Add(numbers[startIndexSequence]);
            }

            return maxRepeatingSequence;
        }
    }
}
