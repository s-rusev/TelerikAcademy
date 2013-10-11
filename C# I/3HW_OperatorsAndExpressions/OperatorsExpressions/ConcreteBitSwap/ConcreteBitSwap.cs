using System;

class ConcreteBitSwap
{
    static void Main()
    {
        uint mask = 7;
        uint maskLowBits = mask << 3;
        //Console.WriteLine("Mask for lower bits: " + Convert.ToString(maskLowBits, 2).PadLeft(32, '0'));
        uint maskHighBits = mask << 24;
        //Console.WriteLine("Mask for higher bits: " + Convert.ToString(maskHighBits, 2).PadLeft(32, '0'));
        Console.WriteLine("Enter a number: ");
        uint num = uint.Parse(Console.ReadLine());
        Console.WriteLine("The number is: " + Convert.ToString(num, 2).PadLeft(32, '0'));
        uint highBits = maskHighBits & num;
        uint lowBits = maskLowBits & num;
        maskLowBits = ~maskLowBits;
        maskHighBits = ~maskHighBits;
        lowBits = lowBits << 21;
        highBits = highBits >> 21;
        num = num & maskHighBits & maskLowBits;
        num = num | lowBits | highBits;
        Console.WriteLine("The number after swapping 3,4,5-th bits with 24,25,26-th is: \n"
            + Convert.ToString(num, 2).PadLeft(32, '0'));
    }
}

