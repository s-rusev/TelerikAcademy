using System;
using System.Numerics;

class FactorialCalc
{
    static void Main()
    {
        //calculates n! / k!
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger res = 1;

        for (int i = Math.Max(n,k); i > Math.Min(n,k); i--)
        {
            res *= i;
        }
        if (n > k)
        {
            Console.WriteLine(res);
        }
        else
        {
            Console.WriteLine(1/res);
        }
    }
}
