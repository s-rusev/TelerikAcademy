using System;
using System.Text.RegularExpressions;

class ExtractAllEmails
{
    static void Main()
    {
        Console.WriteLine("A program that extracts all e-mails in given text.");
        Console.WriteLine("Enter the text:");
        string input = Console.ReadLine();
        Console.WriteLine("The e-mails are:");
        foreach (var email in Regex.Matches(input, @"\w+@\w+\.\w+"))
        {
            Console.WriteLine(email);
        }
    }
}