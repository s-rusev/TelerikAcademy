using System;

//Write a program that reads two arrays from the console and compares them element by element.

class CompareTwoArrays
{
    static void Main()
    {
        Console.WriteLine("Program to compare elements of two arrays:");
        Console.WriteLine("Enter number of elements for the arrays: ");
        int n = int.Parse(Console.ReadLine());
        int[] firstArr = new int[n];
        int[] secondArr = new int[n];
        Console.WriteLine("Enter elements for the first array: ");
        for (int i = 0; i < firstArr.Length; i++)
        {
            firstArr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter elements for the second array: ");
        for (int i = 0; i < secondArr.Length; i++)
        {
            secondArr[i] = int.Parse(Console.ReadLine());
        }
        bool areTheSame = true;
        
        for (int i = 0; i < firstArr.Length; i++)
        {
            if (firstArr[i] > secondArr[i])
            {
                Console.WriteLine(firstArr[i] + ">" + secondArr[i]);
                areTheSame = false;
            }
            else if (firstArr[i] < secondArr[i])
            {
                Console.WriteLine(firstArr[i] + "<" + secondArr[i]);
                areTheSame = false;
            }
            else
            {
                Console.WriteLine(firstArr[i] + "=" + secondArr[i]);
            }
        }

        Console.WriteLine("Are the arrays the same?- {0}",areTheSame);
    }
}
