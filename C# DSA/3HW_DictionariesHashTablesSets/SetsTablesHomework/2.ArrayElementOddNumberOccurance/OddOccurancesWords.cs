using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ArrayElementOddNumberOccurance
{
    public class OddOccurancesWords
    {
        static void Main()
        {
            string[] inputArr = ProcessInput();
            List<string> wordsOddNumberOccurances = GetOddWordsOccurances(inputArr);

            foreach (var item in wordsOddNumberOccurances)
            {
                Console.WriteLine(item);
            }
        }

        private static string[] ProcessInput()
        {
            Console.WriteLine("Enter numbers of elements for the array: ");
            string inputNumber = Console.ReadLine();
            int wordsCount = int.Parse(inputNumber);
            string[] words = new string[wordsCount];
            Console.WriteLine("Enter the elements: ");
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Console.ReadLine();
            }

            return words;
        }

        private static List<string> GetOddWordsOccurances(string[] words)
        {
            Dictionary<string, int> wordOccurances = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordOccurances.ContainsKey(word))
                {
                    wordOccurances[word]++;
                }
                else
                {
                    wordOccurances.Add(word, 1);
                }
            }

            var wordsOddNumberOccurances = from pair in wordOccurances
                                           where pair.Value % 2 != 0
                                           select pair.Key;

            return wordsOddNumberOccurances.ToList();
        }
    }
}
