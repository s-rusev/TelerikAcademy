using System;

//Write a program that finds the maximal increasing 
//sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

class MaximalIncreasingSequence
{
    static void Main()
    {
        Console.WriteLine("Program that finds the longest increasing sequence:");
        Console.WriteLine("Enter number of elements:");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int currentSequenceStart = 0;
        int maxSequenceStart = 0;
        int maxSequenceEnd = 0;
        Console.WriteLine("Enter the elements:");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                int currentSequenceEnd = i - 1;
                if (currentSequenceEnd - currentSequenceStart > maxSequenceEnd - maxSequenceStart)
                {
                    maxSequenceStart = currentSequenceStart;
                    maxSequenceEnd = currentSequenceEnd;
                }
                currentSequenceStart = i;
            }
            else if (i == arr.Length - 1)
            {
                if (!(arr[i - 1] > arr[i]))
                {
                    int currentSequenceEnd = i;
                    if (currentSequenceEnd - currentSequenceStart > maxSequenceEnd - maxSequenceStart)
                    {
                        maxSequenceStart = currentSequenceStart;
                        maxSequenceEnd = currentSequenceEnd;
                    }
                    currentSequenceStart = i;
                }
            }
        }
        Console.WriteLine("The longest increasing sequense is: ");
        for (int i = maxSequenceStart; i <= maxSequenceEnd; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
