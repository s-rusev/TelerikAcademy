using System;

class PrintCombinations
{
    static int maxValue;
    static int numElements;
    static int[] numbers;

    static void Combinations(int position, int after)
    {
        if (position > numElements)
        {
            return;
        }

        for (int i = after ; i <= maxValue; i++)
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
            Console.Write("{0} ", num);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Enter max value: "); //n
        maxValue = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of elements: "); //k
        numElements = int.Parse(Console.ReadLine());
        numbers = new int[numElements];
        Combinations(1, 1);
    }
}
