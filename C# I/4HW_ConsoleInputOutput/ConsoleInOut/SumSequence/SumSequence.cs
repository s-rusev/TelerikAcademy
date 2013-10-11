using System;

    class SumSequence
    {
        static void Main()
        {
            decimal counter = 2m;
            decimal sum = 1m;
            int sign = 1;
            while (1m / counter > 0.00001m)
            {
                sum = sum + (1m / counter) * sign;
                sign = (-sign);
                counter++;
            }

            Console.WriteLine("sum = {0:0.000}", sum);
        }
    }
