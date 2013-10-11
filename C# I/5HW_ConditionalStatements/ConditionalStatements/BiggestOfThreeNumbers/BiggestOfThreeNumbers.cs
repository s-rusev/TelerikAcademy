using System;

class BiggestOfThreeIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number: ");
        int num3 = int.Parse(Console.ReadLine());
        if ((num1 >= num2) && (num1 >= num3))
        {
            Console.WriteLine("{0} is the biggest integer.", num1);
        }
        else if ((num2 >= num1) && (num2 >= num3))
            {
                Console.WriteLine("{0} is the biggest integer.", num2);
            }
            else
            {
                Console.WriteLine("{0} is the biggest integer.", num3);
            }
    }
}