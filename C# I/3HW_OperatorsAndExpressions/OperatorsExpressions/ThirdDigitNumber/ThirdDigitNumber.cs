using System;

class ThirdDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int n = Int16.Parse(Console.ReadLine());
        int temp = n / 100;
        if (temp % 10 == 7)
        {
            Console.WriteLine("The third digit from right to left is 7!");
        }
        else 
        {
            Console.WriteLine("The third digit from right to left is different from 7!");
        }
    }
}

