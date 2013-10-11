using System;

//Write a program that finds in given array of integers a sequence
//of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}	

class SequenceWithSum
{
    static void Main()
    {
        Console.WriteLine("A program that finds a sequence from array with given sum: ");
        Console.WriteLine("Enter number of element of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter the desired sum: ");
        int sum = int.Parse(Console.ReadLine());
        bool foundSolution = false;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int sumSeq = arr[i];
            if (arr[i] == sum)
            {
                Console.WriteLine(arr[i]);
            }
            else
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    sumSeq += arr[j];
                    if (sumSeq == sum)
                    {
                        for (int k = i; k <= j; k++)
                        {
                            Console.WriteLine(arr[k]);
                        }
                        foundSolution = true;
                        break;
                    }
                }
                if (foundSolution)
                {
                    break;
                }
            }
        }
        if (foundSolution == false)
        {
            Console.WriteLine("No such sequence with desired sum.");
        }
    }
}
