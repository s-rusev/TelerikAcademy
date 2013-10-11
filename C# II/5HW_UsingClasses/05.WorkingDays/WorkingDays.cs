using System;

class WorkingDays
{

    public static int FindWorkingDays(DateTime endDate, DateTime[] holidays)
    {
        int numberOfWorkingDays = 0;
        DateTime today = DateTime.Today;
        if (today.Day > endDate.Day && today.Month > endDate.Month && today.Year > endDate.Year)
        {
            Console.WriteLine("The end date is before today!");
            return 0;
        }
        else
        {
            while (today.Day <= endDate.Day && today.Month <= endDate.Month && today.Year <= endDate.Year)
            {
                bool isHoliday = false;
                for (int i = 0; i < holidays.Length; i++)
                {
                    if (today == holidays[i])
                    {
                        isHoliday = true;
                        break;
                    }
                }
                if ((isHoliday == false) && (today.DayOfWeek != DayOfWeek.Saturday) && (today.DayOfWeek != DayOfWeek.Sunday))
                {
                    numberOfWorkingDays++;
                }
                today = today.AddDays(1);
            }
        }
        return numberOfWorkingDays;
    }
    static void Main()
    {
        Console.WriteLine("Enter an end date: (yy/mm/dd) ");
        string input = Console.ReadLine();
        string[] tokens = input.Split('.');
        DateTime endDate = new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
        Console.WriteLine("Enter number of holidays: ");
        int n = int.Parse(Console.ReadLine());
        DateTime[] holidays = new DateTime[n];
        if (n > 0)
        {
            Console.WriteLine("Enter the holiday dates: ");
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                tokens = input.Split('.');
                holidays[i] = new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
            }
        }
        int workingDays = FindWorkingDays(endDate, holidays);
        Console.WriteLine("Working days are: {0}", workingDays);

    }


}
