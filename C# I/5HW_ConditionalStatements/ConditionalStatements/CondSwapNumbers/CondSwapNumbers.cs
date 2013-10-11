using System;

class CondSwapNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers: ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        if (num1 > num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
        }
        Console.WriteLine("Now num1 is- {0} , and num2 is- {1}", num1, num2);
    }
}

