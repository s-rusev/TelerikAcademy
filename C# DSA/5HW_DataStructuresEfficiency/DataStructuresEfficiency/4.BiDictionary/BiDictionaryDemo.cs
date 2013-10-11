using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.BiDictionary
{
    public class BiDictionaryDemo
    {
        static void Main()
        {
            BiKeyDictionary<int, int, string> biKeyDictionary = new BiKeyDictionary<int, int, string>();

            Console.WriteLine("Adding some elements to the bi-dictionary - this may take a while...");
            for (int i = 1; i < 100000; i++)
            {
                biKeyDictionary.Add(i, i + 1, "Value" + i);
                biKeyDictionary.Add(i, i + 1, "Value" + i);
            }

            Console.WriteLine("All items with first key 5000 are:");
            IEnumerable<string> firstKeyValues = biKeyDictionary.FindValuesFirstKey(5000); //should be 2x5000
            foreach (var item in firstKeyValues)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("All items with second key 5000 are:");
            IEnumerable<string> secondKeyValues = biKeyDictionary.FindValuesSecondKey(5000); //should be 2x4999
            foreach (var item in secondKeyValues)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("All items with first key 5000 and second key 5001 are:");
            IEnumerable<string> bothKeyValues = biKeyDictionary.FindValuesTwoKeys(5000, 5001); //should be 2x4999
            foreach (var item in bothKeyValues)
            {
                Console.WriteLine(item);
            }
        }
    }
}
