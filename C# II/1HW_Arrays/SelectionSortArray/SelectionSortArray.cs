﻿using System;

//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
//Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the
//smallest from the rest, move it at the second position, etc.

class SelectionSortArray
{
    static void Main()
    {
        Console.WriteLine("Program that sorts an array of integers with selection sort:");
        Console.WriteLine("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter elements for the array");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < arr.Length-1; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
