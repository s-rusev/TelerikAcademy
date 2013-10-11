using System;
class LargestNumber
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter value (k) : ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the numbers: (each on single line)");
        int lessNumber = 0;
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            if (arr[i] < k)
            {
                lessNumber = arr[i];
            }
        }
        Array.Sort(arr);
        Console.WriteLine("The index is: ");
        int index = 0;
        Console.WriteLine("The sorted array is: ");
        foreach (var num in arr)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("The index of the element less or equal of k in the sorted array is (0-based): ");
        index = Array.BinarySearch(arr, k);
        if (index >= 0)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine(Array.BinarySearch(arr, lessNumber));
        }

    }
}

