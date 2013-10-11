using System;

class SumNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter count of numbers: ");
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            sum += num;
        }
        Console.WriteLine("The sum of the numbers is: {0} ", sum);
    }
}

