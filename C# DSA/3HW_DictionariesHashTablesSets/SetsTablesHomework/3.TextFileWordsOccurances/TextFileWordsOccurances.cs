using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _3.TextFileWordsOccurances
{
    public class TextFileWordsOccurances
    {
        static void Main()
        {
            string[] words = GetWordsFromTextFile("..//..//words.txt");

            //foreach (var item in words)
            //{
            //    Console.WriteLine(item);
            //}

            IDictionary<string, int> occurancesElements = new SortedDictionary<string, int>();
            foreach (var element in words)
            {
                string elementLower = element.ToLower();
                if (occurancesElements.ContainsKey(elementLower))
                {
                    occurancesElements[elementLower]++;
                }
                else
                {
                    occurancesElements.Add(elementLower, 1);
                }
            }

            foreach (var elementOccurance in occurancesElements)
            {
                Console.WriteLine(elementOccurance.Key + " -> " + elementOccurance.Value);
            }
        }

        private static string[] GetWordsFromTextFile(string path)
        {
            string[] words = null;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadToEnd();
                    char[] seperators = new char[] { ' ', '?', '!', '.', ',', '-', '–', '\r', '\n' };
                    words = text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return words;
        }
    }
}
