using System;

class DayOfWeek
{
    static void Main()
    {
        DateTime today = DateTime.Today;
        Console.WriteLine("Today is " + today.DayOfWeek);
    }
}