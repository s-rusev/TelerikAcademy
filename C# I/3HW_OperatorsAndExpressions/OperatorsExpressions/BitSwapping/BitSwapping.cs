using System;


class BitSwapping
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        uint n = UInt32.Parse(Console.ReadLine());
        string numberStr = Convert.ToString(n, 2);
        Console.WriteLine("number is: " + numberStr);
        Console.WriteLine("Enter desired position p and q to swap: ");
        byte posP = byte.Parse(Console.ReadLine());
        byte posQ = byte.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of bits to swap: ");
        byte numberBitsToSwap = byte.Parse(Console.ReadLine());
        uint mask = (uint)(1 << numberBitsToSwap) - 1;
        Console.WriteLine("mask is "+ mask );
        uint maskLowBits = mask << posP;
   //     string maskLowBinaryString = Convert.ToString(maskLowBits, 2);
     //   Console.WriteLine(maskLowBinaryString);

        uint maskHighBits = mask << posQ;
   //     string maskHighBinaryString = Convert.ToString(maskHighBits, 2);
     //   Console.WriteLine(maskHighBinaryString);

        uint lowBits = n & maskLowBits;
        lowBits = lowBits << Math.Abs(posP - posQ);
        uint highBits = n & maskHighBits;
        highBits = highBits >> Math.Abs(posP - posQ);
        maskHighBits = ~maskHighBits;
        maskLowBits = ~maskLowBits;
        n = n & maskHighBits & maskLowBits;
        n = n | lowBits | highBits;
        Console.WriteLine("The new number with swapped bits is: " + n);
        numberStr = Convert.ToString(n, 2);
        Console.WriteLine("Or in binary: " + numberStr);
        
        
     //   Console.WriteLine(maskHighBits);


    }
}

