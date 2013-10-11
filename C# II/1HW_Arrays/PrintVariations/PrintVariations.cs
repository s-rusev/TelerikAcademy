using System;

class PrintVariations
{
    static int[] numbers;
    static int numElements;
    static int maxValue;
    

    static void Main()
    {
        Console.WriteLine("A program that prints all posible variations of n elements with values to k");
        Console.Write("Enter number of elements: ");
        numElements = int.Parse(Console.ReadLine());
        Console.Write("Enter the maximal value: ");
        maxValue = int.Parse(Console.ReadLine());
        numbers = new int[numElements];
        Variations(0);
    }
    static void Variations(int currentVariation)
    {
        if (currentVariation == numElements)
        {
            PrintLoops();
            return;
        }
        for (int counter = 1; counter <= maxValue; counter++)
        {
            numbers[currentVariation] = counter;
            Variations(currentVariation + 1);
        }
    }
    static void PrintLoops()
    {
        foreach (var num in numbers)
        {
            Console.Write("{0} ", num);
        }
        Console.WriteLine();
    }
}