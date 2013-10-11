using System;
using System.Numerics;

class FibonacciNumbers
{
    static void Main(string[] args)
    {
        BigInteger fib1 = 0;
        Console.WriteLine(fib1);
        BigInteger fib2 = 1;
        Console.WriteLine(fib2);
        BigInteger fib3 = 0;
        for (int i = 0; i < 100; i++)
        {
            fib3 = fib1 + fib2;
            Console.WriteLine(fib3);
            fib1 = fib2;
            fib2 = fib3;
        }
    }
}

