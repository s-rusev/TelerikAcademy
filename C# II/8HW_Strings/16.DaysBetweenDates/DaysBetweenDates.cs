using System;
using System.Globalization;

class DaysBetweenDays
{
    static void Main()
    {
       // System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Enter two dates in the format dd.mm.yyyy");
        string start = Console.ReadLine(); // "27.02.2006";
        string end = Console.ReadLine(); // "3.03.2006";

        DateTime startDate = DateTime.ParseExact(start, "d.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(end, "d.MM.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine((endDate - startDate).TotalDays);
    }
}