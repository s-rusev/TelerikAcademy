using System;

//Write a program that finds the maximal sequence of equal elements in an array.
//        Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.


class MaxSequenceRepeatingArray
{
    static void Main()
    {
        Console.WriteLine("Program to find the longest sequence of repeating elements in an array:");
        Console.WriteLine("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int maxSequence = 0;
        int currentMaxSequence = 0;
        int index = 0;
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < arr.Length - 1; i++)
        {
            currentMaxSequence = 1;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {

                    currentMaxSequence++;
                }
                else
                {
                    break;
                }
            }
            if (currentMaxSequence > maxSequence)
            {
                index = i;
                maxSequence = currentMaxSequence;

            }
        }
        Console.WriteLine("The longest sequence is: ");
        for (int i = 0; i < maxSequence; i++)
        {
            Console.WriteLine(arr[index]);
        }
        if (n==1)
        {
            Console.WriteLine(arr[0]);
        }
    }
}
