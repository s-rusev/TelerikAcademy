﻿using System;
using System.Text;

class StringToUnicode
{
    static void Main()
    {
        Console.WriteLine("A program that converts a string to Unicode char literals.");
        Console.WriteLine("Enter a string to show its Unicode representation: ");
        string input = Console.ReadLine();
        StringBuilder unicodeInput = new StringBuilder();

        foreach (char letter in input)
        {
            unicodeInput.AppendFormat("\\u{0:X4}", (int)letter);
        }

        Console.WriteLine("The Unicode representation is: {0}", unicodeInput.ToString());
    }
}