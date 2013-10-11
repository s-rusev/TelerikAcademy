using System;

class NumberDivision
{
    static void Main()
    {
        int n = Int16.Parse(Console.ReadLine());
        if (n % 35 == 0)
        {
            Console.WriteLine("Your number can be divided by 5 and 7 simultaneously! ");
        }
        else
        {
            Console.WriteLine("Your number cannot be divided by 5 and 7 simultaneously! ");
        }
    }
}

