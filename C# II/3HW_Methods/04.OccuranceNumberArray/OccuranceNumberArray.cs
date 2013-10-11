using System;

//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is working correctly.

class OccuranceNumberArray
{
    static int NumberOccurance(int[] array, int number)
    {
        int occuranceCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                occuranceCount++;
            }
        }
        return occuranceCount;
    }
    static void Main()
    {
        Console.WriteLine("Enter numbers of elements for the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the searched element: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        int occurance = NumberOccurance(arr, k);
        Console.WriteLine("The element {0} is {1} times in the array.", k, occurance);
    }
}
