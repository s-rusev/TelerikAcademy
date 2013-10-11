using System;

class SubsetSums
{
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers: ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        int num4 = int.Parse(Console.ReadLine());
        int num5 = int.Parse(Console.ReadLine());
        if ((num1 + num2) == 0)
        {
            Console.WriteLine("Sum of num1 and num2 is 0");
        }
        if ((num1 + num2 + num3) == 0)
        {
            Console.WriteLine("Sum of num1, num2 and num3 is 0");
        }
        if ((num1 + num2 + num3 + num4) == 0)
        {
            Console.WriteLine("Sum of num1, num2, num3 and num4 is 0");
        }
        if ((num1 + num2 + num3 + num4 + num5) == 0)
        {
            Console.WriteLine("Sum of num1, num2, num3, num4 and num5 is 0");
        }
        if ((num2 + num3) == 0)
        {
            Console.WriteLine("Sum of num2 and num3 is 0");
        }
        if ((num2 + num3 + num4) == 0)
        {
            Console.WriteLine("Sum of num2, num3 and num 4 is 0");
        }
        if ((num2 + num3 + num4 + num5) == 0)
        {
            Console.WriteLine("Sum of num2, num3, num4 and num5 is 0");
        }
        if ((num3 + num4) == 0)
        {
            Console.WriteLine("Sum of num3 and num4 is 0");
        }
        if ((num3 + num4 + num5) == 0)
        {
            Console.WriteLine("Sum of num3, num4 and num5 is 0");
        }
        if ((num4 + num5) == 0)
        {
            Console.WriteLine("Sum of num4 and num5 is 0");
        }
        if (num1 == 0)
        {
            Console.WriteLine("The sum of num1 is 0");
        }
        if (num2 == 0)
        {
            Console.WriteLine("The sum of num2 is 0");
        }
        if (num3 == 0)
        {
            Console.WriteLine("The sum of num3 is 0");
        }
        if (num4 == 0)
        {
            Console.WriteLine("The sum of num4 is 0");
        }
        if (num5 == 0)
        {
            Console.WriteLine("The sum of num5 is 0");
        }

    }
}
