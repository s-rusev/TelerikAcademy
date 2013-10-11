using System;
using System.Linq;

class ReverseString
{
    public static string ReverseWord(string text)
    {
        return new string(text.ToCharArray().Reverse().ToArray());
    }

    static void Main()
    {
        Console.WriteLine("Enter a string which will be reversed:");
        string input = Console.ReadLine();
        Console.WriteLine(ReverseWord(input));
    }
}

