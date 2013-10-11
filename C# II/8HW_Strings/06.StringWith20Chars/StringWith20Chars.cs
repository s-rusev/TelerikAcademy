using System;
using System.Linq;

class StringWith20Chars
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = "1234567890";
        if (input.Length > 20)
        {
            throw new ArgumentOutOfRangeException("String length must be less than 20!");
        }
        else if (input.Length < 20)
        {
            input += new string('*', (20 - input.Length));
        }
        Console.WriteLine(input);
    }
}
