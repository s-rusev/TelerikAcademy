using System;
using System.Linq;
using System.Text;

class DecimalToHex
{
    static string ConvertDecimalToHex(int number)
    {
        string result = "";
        while (number > 0)
        {
            int remainder = number % 16;
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
            number /= 16;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter a number in decimal format: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine("The number in its hexadecimal representation is: ");
        Console.WriteLine(ConvertDecimalToHex(input));
    }
}
