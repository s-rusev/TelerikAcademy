using System;

class PrintPermutations
{
    static int n;
    static bool[] used;
    static int[] numbersToPerm;

    static void Permute(int position) 
    {
        if (position >= n)
        {
            PrintPerm();
            return;
        }
        else
        {
            for (int k = 0; k < n; k++)
            {
                if (!used[k])
                {
                    used[k] = true;
                    numbersToPerm[position] = k;
                    Permute(position + 1);
                    used[k] = false;
                }
            }
        }
    }

    public static void PrintPerm()
    {
        foreach (int num in numbersToPerm)
        {
            Console.Write((num +1)+ " ");
        }
        Console.WriteLine();
    }
    
    static void Main()
    {
        Console.WriteLine("Program to print all permutations of n elements.");
        Console.WriteLine("Enter number of elements: ");
        n = int.Parse(Console.ReadLine());
        numbersToPerm = new int[n];
        used = new bool[n];
        for (int i = 0; i < numbersToPerm.Length; i++)
        {
            numbersToPerm[i] = i + 1;
            used[i] = false;
        }

        Permute(0);
    }

}
