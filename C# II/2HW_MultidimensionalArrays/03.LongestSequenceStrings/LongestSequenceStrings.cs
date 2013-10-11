using System;
using System.Collections.Generic;

class LongestSequenceStrings
{
    static List<string> FindLongestSequence(List<string> list)
    {
        int maxSequence = 1;
        int currentMaxSequence = 1;
        int index = 0;
        for (int i = 0; i < list.Count - 1; i++)
        {
            currentMaxSequence = 1;
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i] == list[j])
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
        List<string> result = new List<string>();
        for (int i = 0; i < maxSequence; i++)
        {
            result.Add(list[index]);
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("A program that finds the longest sequence of repeating strings in array verticaly, horizontaly or diagonaly.");
        Console.WriteLine("Enter number of lines: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of elements per line");
        int m = int.Parse(Console.ReadLine());
        string[,] allWords = new string[n, m];
        List<string> wordsToCheck = new List<string>();

        //horizontally
        Console.WriteLine("Enter the elements: (matrix-like, elements seperated with space) ");
        for (int i = 0; i < allWords.GetLength(0); i++)
        {
            string input = Console.ReadLine();
            string[] wordsOnLine = input.Split(' ');
            for (int j = 0; j < wordsOnLine.Length; j++)
            {
                allWords[i, j] = wordsOnLine[j];
                wordsToCheck.Add(wordsOnLine[j]);
            }
        }
        //vertically
        for (int i = 0; i < allWords.GetLength(1); i++)
        {
            for (int j = 0; j < allWords.GetLength(0); j++)
            {
                wordsToCheck.Add(allWords[j, i]);
            }
        }
        //left-right diagonal
        for (int slice = 0; slice < m + n - 1; ++slice)
        {
            int z1 = slice < m ? 0 : slice - m + 1;
            int z2 = slice < n ? 0 : slice - n + 1;
            for (int j = slice - z2; j >= z1; --j)
            {
                wordsToCheck.Add(allWords[j, slice - j]);
            }
        }

        //right-left diagonal
        int k = n - 1;
        for (int slice = 0; slice < 2 * n - 1; slice++)
        {
            int z = slice < n ? 0 : slice - n + 1;
            for (int j = z; j <= slice - z; j++)
            {
                if (z != 0)
                {
                    k = -z;
                }
                wordsToCheck.Add(allWords[j + k, j]);
            }
            --k;
        }

        List<string> result = FindLongestSequence(wordsToCheck);
        Console.WriteLine("The longest sequence is: ");
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }


}
