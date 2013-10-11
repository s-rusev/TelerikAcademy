using System;

//Write a program that finds the index of given element 
//in a sorted array of integers by using the binary search algorithm 

class BinarySearchIndex
{
    static int MyBinarySearch_Iterative(int[] arr, int searchedElement, int leftIndex, int rightIndex)
    {
        int mid;
        while (leftIndex <= rightIndex)
        {
            mid = (leftIndex + rightIndex) / 2;
            if (searchedElement < arr[mid])
                rightIndex = mid - 1; //lower subarray
            else if (searchedElement > arr[mid])
                leftIndex = mid + 1; //upper subarray
            else
                return mid;
        }
        return -1;
    }

    static int MyBinarySearch_Recursive(int[] arr, int searchedElement, int left, int right)
    {
        if (right < left)
        {
            return -1;
        }
        else
        {
            int mid = (left + right) / 2;
            if (arr[mid] > searchedElement)
            {
                return MyBinarySearch_Recursive(arr, searchedElement, left, mid - 1);
            }
            else if (arr[mid] < searchedElement)
            {
                return MyBinarySearch_Recursive(arr, searchedElement, mid + 1, right);
            }
            else
            {
                return mid;
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("Program that finds the index of specific element from sorted array using Binary Search");
        Console.WriteLine("Enter number of elements of array: (not necesseraly sorted) ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter searched element: ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the elements:");

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        Console.WriteLine("The sorted array is: ");
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        int index = Array.BinarySearch(arr, k);
        int index1 = MyBinarySearch_Iterative(arr, k, 0, arr.Length - 1);
        int index2 = MyBinarySearch_Recursive(arr, k, 0, arr.Length - 1);
        if (index1 == -1)
        {
            Console.WriteLine("The element is not in the array!");
        }
        else
        {
            Console.WriteLine("Index of element {0} in the sorted array is-> {1} (using Array.BinarySearch)", k, index);
            Console.WriteLine("Same index using iterative version-> {0}", index1);
            Console.WriteLine("And again the sam using recursive version-> {0}", index2);
        }
    }
}



