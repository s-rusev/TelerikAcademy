using System;

class SumSequence
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        double sum = 1;
        int factorial = 1;
        for (int i = 1; i < n; i++)
        {
            sum += factorial / Math.Pow(x, i);
            factorial *= i;
        }
        Console.WriteLine(sum);
    }
}
