using System;
using System.Text.RegularExpressions;

class AllSentancesWithWord
{
    static void Main()
    {
        Console.WriteLine("A program that prints all sentances containing a word.");
        Console.WriteLine("Enter string to check: ");
        string input = Console.ReadLine();
//@"We are living in a yellow submarine. We don't have anything else. 
//                        Inside the submarine is very tight. So we are drinking all the day.
//                        We will move out of it in 5 days.";
        Console.WriteLine("Enter a word to check: ");
        string wordToCheck = Console.ReadLine(); // "in";
        string[] sentances = input.Split('.');

        foreach (string sentance in sentances)
        {
            if (Regex.Matches(sentance, @"\b" + wordToCheck + @"\b").Count > 0)
            {
                Console.WriteLine(sentance.Trim() + "."); //we assume sentances are separated only by dot 
            }
        }
    }
}

