using System;

class SafelyCompareVars
{
    static void Main()
    {
        //appropriate variables from the first task
        byte byteVar = 97;
        sbyte sbyteVar = -115;
        short shortVar = -10000;
        ushort ushortVar = 52130;
        uint uintVar = 4825932; // or int - both are OK
        decimal firstNum = Decimal.Parse(Console.ReadLine());
        decimal secondNum = Decimal.Parse(Console.ReadLine());
        Console.WriteLine((Math.Abs(firstNum - secondNum) < 0.000001M));
        //declaration of 254 in hexadecimal format
        int hexInt = 0x100;
        bool isFemale = false; //depending on my gender

    }
}

