using System;

class SumString
{
    static void Main()
    {
        Console.WriteLine("Enter a string with numbers: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += int.Parse(numbers[i]);
        }
        Console.WriteLine(sum);
    }
}
