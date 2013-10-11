using System;


class GreaterNumber
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers : ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine("The greater one is {0}", Math.Max(num1,num2));
    }
}

