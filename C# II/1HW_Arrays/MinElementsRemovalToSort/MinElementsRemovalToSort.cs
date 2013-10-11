using System;
using System.Collections.Generic;

//* Write a program that reads an array of integers and removes from it a minimal number of
//elements in such way that the remaining array is sorted in increasing order. Print the remaining
//sorted array. Example:
//    {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

class MinElementsRemovalToSort
{
    static bool checkIfSortedAscending(int[] arr) 
    {
        bool isSorted = true;
        for (int i = 0; i < arr.Length-1; i++)
        {
            if (arr[i] >= arr[i+1])
            {
                isSorted = false;
                break;
            }
        }
        return isSorted;
    }
    static void Main()
    {
        Console.WriteLine("A program that removes minimal number of elements from array in order the rest of it to be sorted.");
        Console.WriteLine("Enter number of elements for the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        string result = "";
     //   int[] resultArr = new int[n];
        Console.WriteLine("Enter the elements of the array: ");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        bool hasSolution = false;
        int binaryCount = (int)Math.Pow(2, n);
        for (int i = 1; i < binaryCount; i++)
        {
            int tempLengthSorted = 0;
            int maxLengthSorted = 0;
            string currentCombination = "";
            for (int j = 0; j < n; j++)
            {
                int mask = 1;
                mask <<= j;
                if (((mask & i) >> j) == 1)
                {
                    currentCombination += arr[j] + " ";
                }
            }
            string[] numbersTokens = currentCombination.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int[] arrayToCheck = new int[numbersTokens.GetLength(0)];
            for (int k = 0; k < numbersTokens.Length; k++)
            {
                arrayToCheck[k] = int.Parse(numbersTokens[k]);
            }
            bool isSorted = checkIfSortedAscending(arrayToCheck);
            if (isSorted)
            {
                tempLengthSorted = arrayToCheck.Length;
                if (tempLengthSorted > maxLengthSorted)
                {
                    maxLengthSorted = tempLengthSorted;
                    result = currentCombination;
                }
                hasSolution = true;
            }
        }
        if (!hasSolution)
        {
            Console.WriteLine("No solution!");
        }
        else
        {
            Console.WriteLine(result);
        }
    }
}
