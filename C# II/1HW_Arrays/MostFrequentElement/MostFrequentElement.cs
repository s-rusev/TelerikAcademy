using System;
using System.Collections.Generic;
using System.Linq;

class MostFrequentElement
{
    //Write a program that finds the most frequent number in an array. 
    //Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

    static void Main()
    {
        Console.WriteLine("A program that finds the most frequent element: ");
        Console.WriteLine("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        SortedDictionary<int, int> numberOfOccurances = new SortedDictionary<int, int>();
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (numberOfOccurances.ContainsKey(number))
            {
                numberOfOccurances[number]++;
            }
            else
            {
                numberOfOccurances.Add(number, 1);
            }
        }
        var max = numberOfOccurances.OrderByDescending(d => d.Value).First();
        var key = max.Key;
        Console.WriteLine(key +"->" + max.Value +" times");
    }
}

/* 
 *  aaannnddd another solution...
using System;

class MostFrequentNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        int maxCount = 1;
        int currentCount = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i-1]==arr[i])
            {
                currentCount++;
            }
            else if (maxCount < currentCount)
            {
                maxCount = currentCount;
                index = i-1;
                currentCount = 0;
            }
        }
        Console.WriteLine(arr[index]);
    }
}
*/
