using System;

class DivisorsOfFive
{
    static void Main()
    {
        Console.WriteLine("Enter the lower bound: ");
        int lowBound = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the higher bound: ");
        int highBound = int.Parse(Console.ReadLine());
        int divFiveCount = 0;
        for (int i = lowBound; i <= highBound; i++)
        {
            if (i % 5 == 0)
            {
                ++divFiveCount;
            }
        }
        Console.WriteLine("Number of divisors of 5 is {0}", divFiveCount);
    }
}