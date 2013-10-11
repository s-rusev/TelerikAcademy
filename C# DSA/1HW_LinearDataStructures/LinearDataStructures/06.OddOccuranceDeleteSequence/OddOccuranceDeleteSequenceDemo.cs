using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.OddOccuranceDeleteSequence
{
    public class OddOccuranceDeleteSequenceDemo
    {
        static void Main()
        {
            Console.WriteLine("Enter values until empty line is entered:");
            Dictionary<int, int> numbersOccurances = ProcessInput();
            DeleteOddCountOccurances(ref numbersOccurances);

            Console.WriteLine("Elements that occur odd times are deleted. Now elements are: ");
            foreach (var item in numbersOccurances)
            {
                Console.WriteLine(item.Key + "->" + item.Value);
            }
        }

        private static void DeleteOddCountOccurances(ref Dictionary<int, int> numbersOccurances)
        {
            var itemsToRemove = numbersOccurances.Where(keyValue => (keyValue.Value % 2 != 0)).ToList();
            foreach (var item in itemsToRemove)
            {
                numbersOccurances.Remove(item.Key);
            }
        }

        private static Dictionary<int, int> ProcessInput()
        {
            Dictionary<int, int> numbersOccurances = new Dictionary<int, int>();

            string inputNumber = Console.ReadLine();
            while (inputNumber != String.Empty)
            {
                int number;
                bool isValidNumber = int.TryParse(inputNumber, out number);
                if (isValidNumber)
                {
                    if (numbersOccurances.ContainsKey(number))
                    {
                        numbersOccurances[number]++;
                    }
                    else
                    {
                        numbersOccurances.Add(number, 1);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }

                inputNumber = Console.ReadLine();
            }


            return numbersOccurances;
        }
    }
}
