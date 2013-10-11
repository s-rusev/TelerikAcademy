using System;

namespace _5.BitArray64
{
    class BitArrayTest 
    {
        static void Main() 
        {
            BitArray64 firstBitArray = new BitArray64(31);
            Console.WriteLine("Demonstrating IEnumerable: ");
            foreach (var item in firstBitArray)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine("ToString() method:");
            Console.WriteLine(firstBitArray.ToString());
            Console.WriteLine();
            BitArray64 secondBitArray = new BitArray64(31);
            Console.WriteLine("Second bit array hash code -> " + secondBitArray.GetHashCode());
            Console.WriteLine("Is first bit array the same as the second? -> " + firstBitArray.Equals(secondBitArray));
            Console.WriteLine("The last bit of the second bit array is " + secondBitArray[63]);
            //Console.WriteLine(second[123]); will break
        }
    }
}

