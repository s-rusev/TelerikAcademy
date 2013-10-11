using System;
using System.Collections.Generic;


class WordsDictionary
{
    public static string GetDescription(string word)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add(".NET", "platform for applications from Microsoft");
        dictionary.Add("CLR", "managed execution environment for .NET");
        dictionary.Add("namespace", "hierarchical organization of classes");

        foreach (KeyValuePair<string, string> entry in dictionary)
        {
            if (entry.Key.ToLower() == word.ToLower())
            {
                return entry.Value;
            }
        }
        return "No such word in dictionary!";
    }

    static void Main()
    {
        Console.Write("Search for a word: ");
        string word = Console.ReadLine();
        Console.WriteLine("{0} - {1}", word, GetDescription(word));
    }
}
