using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TrieWordsOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            ITrie trie = TrieFactory.GetTrie();
            string[] wordsToAdd = 
                        { 
                            "THIS", "TEST", "THE", "TEMP", "TOKEN", "TAKE", "THUMP",
                            "this", "test", "the", "temp", "token", "take", "thump",
                            "123", "1", "23" , "ZZ", "zz"
                        };

            foreach (string word in wordsToAdd)
            {
                trie.AddWord(word);
            }

            var prefixWordsEmpty = trie.GetWords("");
            Console.WriteLine("Prefix \"\":");
            PrintCollection(prefixWordsEmpty);
            Console.WriteLine("Prefix th:");
            var prefixWords1 = trie.GetWords("th");
            PrintCollection(prefixWords1);
            var prefixWords1Upper = trie.GetWords("TH");
            Console.WriteLine("Prefix TH:");
            PrintCollection(prefixWords1Upper);
            var prefixWords2 = trie.GetWords("z");
            Console.WriteLine("Prefix z");
            PrintCollection(prefixWords2);
            var prefixWords2Upper = trie.GetWords("Z");
            Console.WriteLine("Prefix Z");
            PrintCollection(prefixWords2Upper);
            var prefixWords3Digits = trie.GetWords("1");
            Console.WriteLine("Prefix 1");
            PrintCollection(prefixWords3Digits);
        }

        private static void PrintCollection(ICollection<string> aCollection) 
        {
            foreach (var entry in aCollection) 
            {
                Console.WriteLine(entry);
            }
        }

    }
}
