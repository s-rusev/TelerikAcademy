using System;
using System.Numerics;

class FibonacciSum
{
    static void Main()
    {
        BigInteger fib1 = 0;
        BigInteger fib2 = 1;
        BigInteger fib3 = 0;
        int n = int.Parse(Console.ReadLine());
        BigInteger sumFib = 1;
        for (int i = 2; i < n; i++)
        {
            fib3 = fib1 + fib2;
            sumFib += fib3;
            fib1 = fib2;
            fib2 = fib3;
        }
        if (n == 1)
        {
            sumFib = 0;
        }
        Console.WriteLine(sumFib);
    }
}

