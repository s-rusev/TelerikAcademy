﻿﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractAllDates
{
    static void Main()
    {
        Console.WriteLine("A program that extract all the dates from given text.");
        Console.WriteLine("Enter the text:");
        string input = Console.ReadLine();
        Console.WriteLine("The dates are:");
        foreach (Match item in Regex.Matches(input, @"\d{1,2}.\d{1,2}.\d{4}"))
        {
            DateTime date = new DateTime();
            if (DateTime.TryParseExact(item.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }
    }
}