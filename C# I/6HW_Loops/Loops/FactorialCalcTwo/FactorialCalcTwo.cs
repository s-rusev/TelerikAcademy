using System;
using System.Numerics;

class FactorialCalcTwo
{
    static void Main()
    {
        //        N!*K! / (K-N)! for given N and K (1<N<K).
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger nFact = 1;
        BigInteger kFact = 1;
        BigInteger divisor = 1;
        for (int i = 1; i <= k - n; i++)
        {
            divisor *= i;
        }
        for (int i = k-n; i <= n; i++)
        {
            nFact *= i;
        }
        for (int i = n; i <= k; i++)
        {
            kFact *= i;
        }
        Console.WriteLine((kFact*nFact)/divisor);

    }
}

