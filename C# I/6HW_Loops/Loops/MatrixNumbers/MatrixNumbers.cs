using System;

class MatrixNumbers
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                string num = (j + i) + " ";
                Console.Write(num.PadLeft(5));
            }
            Console.WriteLine();
        }
    }
}
