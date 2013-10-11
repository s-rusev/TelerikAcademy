using System;

//* We are given an array of integers and a number S. Write a program to find
//if there exists a subset of the elements of the array that has a sum S. Example:
//    arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

class SubsetWithSumS
{

    static void Main()
    {
        Console.WriteLine("A program that finds subsets with specific sum from an array.");
        Console.WriteLine("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the desired sum: ");
        int sum = int.Parse(Console.ReadLine());
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
            for (int j = 0; j < n; j++)
            {
                int mask = 1;
                mask <<= j;
                if (((mask & i) >> j) == 1)
                {
                    tempSum += arr[j];
                    if (result.Length != 0 && arr[j] > 0)
                    {
                        result += "+";
                    }
                    result += arr[j];
                }
            }

            if (tempSum == sum)
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
