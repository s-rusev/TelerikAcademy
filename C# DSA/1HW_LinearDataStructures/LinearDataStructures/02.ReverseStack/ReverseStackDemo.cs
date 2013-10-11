using System;
using System.Collections.Generic;

namespace _02.ReverseStack
{
    public class ReverseStackDemo
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();
            Console.WriteLine("Enter number of elements:");
            int numbersCount = GetValidNumber();

            Console.WriteLine("Enter the elements:");
            for (int i = 0; i < numbersCount; i++)
            {
                int numberToAdd = GetValidNumber();
                numbers.Push(numberToAdd);
            }

            Stack<int> reversedNumbers = GetReversedStack(numbers);
            //now items are reversed and when we print them
            //we will get them in the same order as we entered them
            //(because of stack's nature)
            //so that's why we reverse them twice (just for demonstration
            //that it works :))
            reversedNumbers = GetReversedStack(reversedNumbers);

            Console.WriteLine("Reversed (reversed) items in the stack:");
            foreach (var item in reversedNumbers)
            {
                Console.WriteLine(item);
            }
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

        private static Stack<int> GetReversedStack(Stack<int> stackToReverse) 
        {
            Stack<int> reversedStack = new Stack<int>();
            foreach (var item in stackToReverse)
            {
                reversedStack.Push(item);
            }

            return reversedStack;
        }
    }
}
