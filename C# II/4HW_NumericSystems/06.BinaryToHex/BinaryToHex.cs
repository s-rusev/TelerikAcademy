using System;

class BinaryToHex
{
    static void Main()
    {
        Console.WriteLine("Enter a number with binary representation: ");
        string input = Console.ReadLine();
        //add zeroes in the begining of the number
        if (input.Length % 4 != 0)
        {
            switch (input.Length % 4)
            {
                case 1:
                    input = "000" + input;
                    break;
                case 2:
                    input = "00" + input;
                    break;
                case 3:
                    input = "0" + input;
                    break;
            }
        }
        Console.WriteLine(input);
        string result = "";
        for (int i = 0; i < input.Length; i += 4)
        {
            switch (input.Substring(i, 4))
            {
                case "0000": result += "0"; break;
                case "0001": result += "1"; break;
                case "0010": result += "2"; break;
                case "0011": result += "3"; break;
                case "0100": result += "4"; break;
                case "0101": result += "5"; break;
                case "0110": result += "6"; break;
                case "0111": result += "7"; break;
                case "1000": result += "8"; break;
                case "1001": result += "9"; break;
                case "1010": result += "A"; break;
                case "1011": result += "B"; break;
                case "1100": result += "C"; break;
                case "1101": result += "D"; break;
                case "1110": result += "E"; break;
                case "1111": result += "F"; break;
                default: result += ""; break;
            }
        }
        //remove zeroes from begining if any
        if (result != "0")
        {
            for (int i = 0; i < result.Length - 1; i++)
            {
                if (result[i] == '0')
                {
                    result = result.Substring(i + 1);
                }
                else
                {
                    break;
                }
            }
        }
        Console.WriteLine("The number in hexadecimal representation is: ");
        Console.WriteLine(result);
    }
}
