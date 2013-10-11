using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.NumberOccurancesSequence
{
    public class NumberOccurancesSequenceDemo
    {
        static void Main()
        {
            Console.WriteLine("Enter values until empty line is entered:");
            Dictionary<int, int> numbersOccurances = ProcessInput();

            foreach (var item in numbersOccurances)
            {
                Console.WriteLine(item.Key + "->" + item.Value);
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
                bool isInRange = (number >= 0 && number <= 1000);

                if (isValidNumber && isInRange)
                {
                    if (numbersOccurances.ContainsKey(number))
                    {
                        numbersOccurances[number]++;
                    }
                    else
                    {
                        //no occurances of the number -> add it with occurance count 1
                        numbersOccurances.Add(number, 1);
                    }
                }
                else
                {
                    Console.WriteLine("Number must be valid and between 0 and 1000 inclusive!");
                }

                inputNumber = Console.ReadLine();
            }


            return numbersOccurances;
        }
    }
}
