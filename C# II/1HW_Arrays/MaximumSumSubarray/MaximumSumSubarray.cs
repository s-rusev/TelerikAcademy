using System;

//Write a program that finds the sequence of maximal sum in given array. Example:
//    {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}

class MaximumSumSubarray
{
    public struct res
    {
        public int index;
        public int count;
        public res(int i, int c)
        {
            index = i;
            count = c;
        }
    }
    static res MaxSubArraySum(int[] arr)
    {
        int maxEndingHere = 0;
        int maxSum = 0;
        int index = 0;
        int counter = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            maxEndingHere = Math.Max(0, maxEndingHere + arr[i]);
            if (maxEndingHere > maxSum)
            {
                index = i;
                maxSum = maxEndingHere;
                counter++;
            }
        }
        res result = new res(index, counter);
        return result;
    }
    static void Main()
    {
        Console.WriteLine("A program that finds the maximum sum of subarray in an array: ");
        // doing it with a single scan through the elements of the array
        Console.WriteLine("Enter number of elements of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        res result = MaxSubArraySum(arr);
        Console.WriteLine("The maximum subarray sum is from the sequence: ");
        
        for (int i = result.index - result.count + 1; i <= result.index; i++)
        {
            Console.WriteLine(arr[i]);
        }

    }
}
