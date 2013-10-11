using System;

class GreatestNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int max = int.Parse(Console.ReadLine());
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("Enter a number");
            int a = int.Parse(Console.ReadLine());
            if (a >= max)
            {
                max = a;
            }
        }
        Console.WriteLine("Greatest number is {0}" , max);
        
    }
}

