using System;

class HexToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter a number in its hexadecimal representation: ");
        string input = Console.ReadLine();
        int result = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            int numToAdd = input[i];
            if (input[i] >= 'A')
            {
                numToAdd = input[i] - 'A' + 10;
            }
            else
            {
                numToAdd = input[i] - '0';
            }
            result += numToAdd * (int)Math.Pow(16, input.Length - 1 - i);
        }
        Console.WriteLine("The decimal representation is: {0}", result);
    }
}
