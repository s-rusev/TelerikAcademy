using System;

class ShortTypeBinary
{

    static string DecimalToBinary(short number)
    {
        string result = "";
        if (number == 0)
        {
            return result = "0";
        }
        while (number > 0)
        {
            result = (number % 2) + result;
            number /= 2;
        }
        return result;
    }
    static void Main()
    {
        Console.WriteLine("Enter a short number with its decimal representation: ");
        short input = short.Parse(Console.ReadLine());
        //  Console.WriteLine(Convert.ToString(input, 2)); this is to check the corectness of the result
        Console.WriteLine("The binary representation is: ");
        if (input >= 0)
        {
            Console.WriteLine(DecimalToBinary(input));
        }
        else
        {
            string reversed = "";
            string result = "";
            input = (short)Math.Abs(input + 1);
            reversed += DecimalToBinary(input);
            //add zeroes
            while (reversed.Length % 16 != 0)
            {
                reversed = "0" + reversed;
            }
            for (int i = 0; i < reversed.Length; i++)
            {
                if (reversed[i] == '0')
                {
                    result += 1;
                }
                else
                {
                    result += 0;
                }
            }
            Console.WriteLine(result);
        }
    }
}
