using System;
using System.Numerics;

class FactorialCalculation
{
    static void Main()
    {
        Console.WriteLine("A program printing all the factorials from 1 to 100");
        for (int i = 1; i <= 100; i++)
        {
            Factorial(i);
        }
    }
    static void Factorial(int n)
    {
        BigInteger fact = 1;
        //actually we can use the solution from task 8 because multiplication is actually addition many times :)
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }
        Console.WriteLine(fact);
    }
}