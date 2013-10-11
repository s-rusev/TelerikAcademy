using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ReverseWordsSentance
{
    class ReverseWordsSentance
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            Array.Reverse(words);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
        }
    }
}
