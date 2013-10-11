using System;

//Write a program that reads two integer numbers N and K and an array of N 
//elements from the console. Find in the array those K elements that have maximal sum.

class MaxSumWithNelements
{
    static void Main()
    {
        Console.WriteLine("Program that reads an array of n elements and finds in it k-elements with the biggest sum:");
        Console.WriteLine("Enter n= ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter k= ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of the array: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        Console.WriteLine("The maximum sum with k-elements is: ");
        for (int i = arr.Length - 1; i > (arr.Length - 1 - k); i--)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
