using System;

class TrailingZerosFactorial
{
    static void Main()
    {
        //finds number of trailing zeros in n!
        int n = int.Parse(Console.ReadLine());
        long result = 0;
        for (int i = 5; i <= n; i *= 5)
        {
            result = result + (n / i);
        }
        Console.WriteLine(result);
    }
}
