using System;

class PrintCombinations
{
    //The same task as task number 3 :)    
    static int numElements;
    static int[] numbers;
    static string[] words = { "test", "rock", "fun" };
    static int maxValue = words.Length;

    static void Combinations(int position, int after)
    {
        if (position > numElements)
        {
            return;
        }

        for (int i = after + 1; i <= maxValue; i++)
        {
            numbers[position - 1] = i;
            if (position == numElements)
            {
                PrintCombination();
            }
            Combinations(position + 1, i);
        }
    }
    static void PrintCombination()
    {
        foreach (var num in numbers)
        {
            Console.Write("{0} ", words[num - 1]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        numElements = 2;
        numbers = new int[numElements];
        Combinations(1, 0);
    }
}
