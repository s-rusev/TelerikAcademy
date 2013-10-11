using System;
using System.Globalization;
using System.Linq;
using System.Threading;

class ReverseNumber
{
    static string ReverseNum(decimal number)
    {
        return new string(number.ToString().ToCharArray().Reverse().ToArray());
    }
    
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        decimal inputDec = decimal.Parse(Console.ReadLine());
        Console.WriteLine(ReverseNum(inputDec));
    }
}
