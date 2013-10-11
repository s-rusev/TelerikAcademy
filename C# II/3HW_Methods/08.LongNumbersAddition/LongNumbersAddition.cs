using System;

class LongNumberAddition
{
    static string CalculateLongNumbers(byte[] first, byte[] second)
    {
        string result = "";
        int length = (int)Math.Max(first.Length, second.Length);
        byte[] resultDigits = new byte[length];
        byte remainder = 0;
        int minLength = (int)Math.Min(first.Length, second.Length);
        for (int i = 0; i < minLength; i++)
        {
            resultDigits[i] = (byte)((first[i] + second[i]) % 10 + remainder);
            remainder = (byte)((first[i] + second[i]) / 10);
        }
        if (first.Length > second.Length)
        {
            for (int i = minLength; i < length; i++)
            {
                resultDigits[i] = (byte)((first[i] + remainder));
                remainder = (byte)(resultDigits[i] / 10);
                resultDigits[i] %= 10;
            }
        }
        else if (first.Length < second.Length)
        {
            for (int i = minLength; i < length; i++)
            {
                resultDigits[i] = (byte)((second[i] + remainder));
                remainder = (byte)(resultDigits[i] / 10);
                resultDigits[i] %= 10;
            }
        }
        for (int i = 0; i < resultDigits.Length; i++)
        {
            result += resultDigits[resultDigits.Length - 1 - i];
        }
        if (result[0] == '0')
        {
            result = result.Substring(1);
        }
        return result;
    }

    static void Main()
    {
        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine();
        string firstNumberStr = "";
        string secondNumberStr = "";
        //add zero at the begining of the longer number
        if (input1.Length >= input2.Length)
        {
            firstNumberStr = "0" + input1;
            secondNumberStr = input2;
        }
        else
        {
            firstNumberStr = input1;
            secondNumberStr = "0" + input2;
        }
        byte[] firstNumberDigits = new byte[firstNumberStr.Length];
        for (int i = firstNumberDigits.Length - 1; i >= 0; i--)
        {
            firstNumberDigits[firstNumberDigits.Length - 1 - i] = byte.Parse(firstNumberStr[i].ToString());
        }
        byte[] secondNumberDigits = new byte[secondNumberStr.Length];
        for (int i = secondNumberDigits.Length - 1; i >= 0; i--)
        {
            secondNumberDigits[secondNumberDigits.Length - 1 - i] = byte.Parse(secondNumberStr[i].ToString());
        }
        Console.WriteLine(CalculateLongNumbers(firstNumberDigits, secondNumberDigits));
    }
}
