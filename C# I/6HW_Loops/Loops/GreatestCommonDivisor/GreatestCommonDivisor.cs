using System;

class GreatestCommonDivisor
{
    static int GCD(int a, int b)
    {
        int Remainder;
        while (b != 0)
        {
            Remainder = a % b;
            a = b;
            b = Remainder;
        }

        return a;
    }

    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        Console.WriteLine(GCD(x, y));
    }
}

