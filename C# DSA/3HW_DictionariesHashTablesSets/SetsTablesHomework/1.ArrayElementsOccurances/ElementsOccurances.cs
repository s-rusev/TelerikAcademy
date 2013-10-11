using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ArrayElementsOccurances
{
    public class ElementsOccurances
    {
        static void Main()
        {
            //string inputElements = Console.ReadLine();
            //int numberElements = int.Parse(inputElements);
            double[] sampleArray = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            //for (int i = 0; i < numberElements; i++)
            //{
            //    sampleArray[i] = int.Parse(Console.ReadLine());
            //}
            IDictionary<double, int> occurancesElements = new Dictionary<double, int>();
            foreach (var element in sampleArray)
            {
                if (occurancesElements.ContainsKey(element))
                {
                    occurancesElements[element]++;
                }
                else
                {
                    occurancesElements.Add(element, 1);
                }
            }

            foreach (var elementOccurance in occurancesElements)
            {
                Console.WriteLine(elementOccurance.Key + " -> " + elementOccurance.Value);
            }
        }
    }
}
