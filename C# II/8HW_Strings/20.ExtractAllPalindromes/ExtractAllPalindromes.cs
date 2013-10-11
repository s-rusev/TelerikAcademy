using System;
using System.Text.RegularExpressions;

class ExtractAllPalindromes
{
    static bool IsPalindrome(string str)
    {
        bool isPalindrome = true;
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - 1 - i])
            {
                isPalindrome = false;
            }
        }
        return isPalindrome;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        foreach (Match word in Regex.Matches(input, @"\w+"))
        {
            if (IsPalindrome(word.Value))
            {
                Console.WriteLine(word);
            }
        }
    }
}