using System;


class SumThreeInts
{
    static void Main()
    {
        Console.WriteLine("Enter first number ");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number ");
        int num3 = int.Parse(Console.ReadLine());
        Console.WriteLine("The sum of the three numbers is: {0} ", num1+num2+num3);
    }
}

