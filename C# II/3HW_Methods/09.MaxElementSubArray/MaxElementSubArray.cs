using System;

//Write a method that return the maximal element in a portion of array of
//integers starting at given index. Using it write another method that sorts
//an array in ascending / descending order.

class MaxElementSubArray
{
    static int MaxElement(int[] arr, int index)
    {
        int maxNum = arr[index];
        for (int i = index; i < arr.Length; i++)
        {
            if (maxNum < arr[i])
            {
                maxNum = arr[i];
            }
        }
        return maxNum;
    }

    static void SortUsingMaxElement(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1 ; i++)
        {
            int max = MaxElement(arr, i);
            for (int j = i; j < arr.Length ; j++)
            {
                if (arr[j] == max)
                {
                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter numbers of elements for the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter index from which to search rest of the array for the biggest element: (0-based)");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("The biggest element (startin from index {0}) is -> {1}" , k , MaxElement(arr,k));
        SortUsingMaxElement(arr);
        Console.WriteLine("The descending sorted array (using the Maxfind method) is: ");
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
        

    }
}