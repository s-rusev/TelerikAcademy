using System;

class MinMaxElement
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int max = 0;
        int min = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num > max)
            {
                max = num;
            }
            if (num < min) 
            {
                min = num;
            }
        }
        Console.WriteLine("Minimal element is: {0} and maximum is: {1}", min, max);
    }
}

