using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalanNumbers
{
    class CatalanNumbers
    {
        static double Factorial(double n)
        {
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }
        static double CatalanNumber(double n)
        {
            return Factorial(2.0 * n) / (Factorial(n + 1) * Factorial(n));
        }
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double nthCatalanNumber = CatalanNumber(n);
            Console.WriteLine(nthCatalanNumber);
        }
    }
}
