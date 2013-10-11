using System;

//Write a program that finds all prime numbers in the range [1...10 000 000].
//Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

class PrimeNumbers
{
    static public void CalculatePrintPrimeNumbers(long max)
    {
        bool[] isPrime = new bool[max];
        for (int i = 0; i < max; i++)
        {
            isPrime[i] = true;
        }
        for (long i = 2; i * i <= max; i++)
        {
            if (isPrime[i] == true)
            {
                for (long j = i * 2; j < max; j += i)
                {
                    isPrime[j] = false;
                }
            }
            else
            {
                continue;
            }
        }
        for (int i = 1; i < max; i++)
        {
            if (isPrime[i])
            {
                Console.WriteLine(i);
            }
        }
    }
    static void Main()
    {
        CalculatePrintPrimeNumbers(10000000);
        Console.WriteLine("That are all the prime numbers to 10000000.");
    }
}
