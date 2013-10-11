﻿using System;
using System.Globalization;

class DateAfterAddTime
{
    static void Main()
    {
        Console.WriteLine("Enter a date in the format [dd.mm.yyyy hh:mm:ss]");
        string input = Console.ReadLine();//"24.01.2013 23:00:00";
        DateTime date = DateTime.ParseExact(input, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        date = date.AddHours(6.5);
        Console.WriteLine("The date (in bulgarian) after 6 hours 30 minutes is: {0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date);
    }
}