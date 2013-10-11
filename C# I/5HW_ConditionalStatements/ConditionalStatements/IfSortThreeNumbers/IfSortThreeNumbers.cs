using System;

class IfSortThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number: ");
        int num3 = int.Parse(Console.ReadLine());
        if (num1 <= num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
        }
        if (num2 <= num3)
        {
            num2 = num2 + num3;
            num3 = num2 - num3;
            num2 = num2 - num3;
        }
        if (num1 <= num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
        }

        Console.WriteLine("Numbers in descending order are {0} {1} {2}", num1, num2, num3);
    }
}

