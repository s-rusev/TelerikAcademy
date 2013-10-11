using System;
using System.Text;
using System.Text.RegularExpressions;


class CensoreForbiddenWords
{
    static void Main()
    {
        Console.WriteLine("A program that censores forbidden words (case sensitive).");
        Console.WriteLine("Enter sentance to censore: ");
        StringBuilder censoredText = new StringBuilder();
        censoredText.Append(Console.ReadLine());
//            @"Microsoft announced its next generation PHP compiler today.
//It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        Console.WriteLine("Enter words to censore (separated by comma):");
        string words = Console.ReadLine();//"PHP, CLR, Microsoft";
        string[] forbiddenWords = words.Split(',');
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            string forbidenWord = forbiddenWords[i].Trim();
            censoredText = censoredText.Replace(forbidenWord, new string('*', forbidenWord.Length));
        }
        Console.WriteLine(censoredText);
    }
}