using System;

//* Write a program that reads three integer numbers N, K and S and an array of N
//elements from the console. Find in the array a subset of K elements that have sum 
//S or indicate about its absence.

class SubsetWithSumSAndKElem
{
    static void Main()
    {
        Console.WriteLine("A program that finds subsets with specific number of elements and sum from an array.");
        Console.WriteLine("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the desired sum: ");
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of elements: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements of the array: ");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        bool hasSolution = false;
        int binaryCount = (int)Math.Pow(2, n);
        for (int i = 1; i < binaryCount; i++)
        {
            int tempSum = 0;
            string result = "";
            int countUsedDigits = 0;
            for (int j = 0; j < n; j++)
            {
                int mask = 1;
                mask <<= j;
                if (((mask & i) >> j) == 1)
                {
                    countUsedDigits++;
                    tempSum += arr[j];
                    if (result.Length != 0 && arr[j] > 0)
                    {
                        result += "+";
                    }
                    result += arr[j];
                }
            }
            if (tempSum == sum && countUsedDigits==k)
            {
                Console.WriteLine(result + "= {0}", sum);
                hasSolution = true;
            }
        }
        if (!hasSolution)
        {
            Console.WriteLine("No solution!");
        }
    }
}
