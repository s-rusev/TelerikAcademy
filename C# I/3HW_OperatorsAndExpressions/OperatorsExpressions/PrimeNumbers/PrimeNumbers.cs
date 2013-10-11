using System;

    class PrimeNumbers
    {
        static void Main()
        {
            int n = Int16.Parse(Console.ReadLine());
            bool isPrime = true;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine("Is {0} prime? - {1}", n, isPrime);
        }
    }

