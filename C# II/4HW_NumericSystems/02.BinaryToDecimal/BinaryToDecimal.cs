using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter a number in its binary representation: ");
        string input = Console.ReadLine();
        int result = 0;
        for (int i = input.Length-1; i >= 0 ; i--)
        {
            result += (input[i] - '0') * (int)Math.Pow(2, input.Length - 1 - i);
        }
        Console.WriteLine("The decimal representation is: {0}" , result);
    }
}
