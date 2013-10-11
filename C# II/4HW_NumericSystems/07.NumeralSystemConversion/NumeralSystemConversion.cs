using System;

class NumeralSystemConversion
{
    static int ConvertToDecimal(string numberToConvert, byte systemBase)
    {
        int result = 0;
        for (int i = numberToConvert.Length - 1; i >= 0; i--)
        {
            int numToAdd = numberToConvert[i];
            if (numberToConvert[i] >= 'A')
            {
                numToAdd = numberToConvert[i] - 'A' + 10;
            }
            else
            {
                numToAdd = numberToConvert[i] - '0';
            }
            result += numToAdd * (int)Math.Pow(systemBase, numberToConvert.Length - 1 - i);
        }
        return result;
    }

    static string ConvertFromDecimalToBase(int number, byte systemBase)
    {
        string result = "";
        while (number > 0)
        {
            int remainder = number % systemBase;
            char numToAdd;
            if (remainder >= 10)
            {
                numToAdd = (char)('A' + remainder - 10);
            }
            else
            {
                numToAdd = (char)('0' + remainder);
            }
            result = numToAdd + result;
            number /= systemBase;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter a number and after that the base of its representation: ");
        string input = Console.ReadLine();
        Console.WriteLine("Now enter the base: ");
        byte baseSystemInput = byte.Parse(Console.ReadLine());
        Console.WriteLine("Enter base for the number to be converted: ");
        byte baseSystemOutput = byte.Parse(Console.ReadLine());
        int inputDecimal = ConvertToDecimal(input, baseSystemInput);
        string res = ConvertFromDecimalToBase(inputDecimal, baseSystemOutput);
        Console.WriteLine("The number {0} in representation with base {1} is {2}",input, baseSystemOutput, res);
    }
}
