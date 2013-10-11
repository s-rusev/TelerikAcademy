using System;

class LeapYear
{
    static void Main()
    {
        Console.WriteLine("Enter an year:");
        string input = Console.ReadLine();
        DateTime date = new DateTime(int.Parse(input), 1, 1);
        bool isLeap = DateTime.IsLeapYear(date.Year);
        Console.WriteLine("Is the year leap?- {0}", isLeap);
    }
}
