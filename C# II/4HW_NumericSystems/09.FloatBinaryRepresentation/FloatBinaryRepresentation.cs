using System;
using System.Text;

class FloatBinaryRepresentation
{
    static string HexToBinary(string input) 
    {
        string result = "";
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i].ToString())
            {
                case "0": result += "0000"; break;
                case "1": result += "0001"; break;
                case "2": result += "0010"; break;
                case "3": result += "0011"; break;
                case "4": result += "0100"; break;
                case "5": result += "0101"; break;
                case "6": result += "0110"; break;
                case "7": result += "0111"; break;
                case "8": result += "1000"; break;
                case "9": result += "1001"; break;
                case "A": result += "1010"; break;
                case "B": result += "1011"; break;
                case "C": result += "1100"; break;
                case "D": result += "1101"; break;
                case "E": result += "1110"; break;
                case "F": result += "1111"; break;
                default: result += ""; break;
            }
        }
        return result;
    }
    static void Main()
    {
        Console.WriteLine("Enter a single-precision floating-point number: ");
        float input = Single.Parse(Console.ReadLine());
        byte[] raw = BitConverter.GetBytes(input);
        Array.Reverse(raw);
        string result = BitConverter.ToString(raw);
        StringBuilder sb = new StringBuilder(32);
        foreach (char c in result)
        {
            sb.Append(HexToBinary(c.ToString()));
        }
        result = sb.ToString();
        Console.WriteLine("Sign is: {0}", result[0]);
        Console.WriteLine("Exponent is {0}", result.Substring(1,8));
        Console.WriteLine("Mantissa is {0}", result.Substring(9));
    }
}
