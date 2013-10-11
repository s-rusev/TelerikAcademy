using System;
/*
 * Checks if the third bit of a number is 0 or 1 (counting from 0)
 */
class ThirdBitNum
{
    static void Main()
    {
        int position = 4;
        Console.WriteLine("Enter a number: ");
        int n = Int16.Parse(Console.ReadLine());
        int i = 1;
        int mask = i << position;
        Console.WriteLine("The third bit is: " + ((n & mask) == 0 ? 0 : 1));
    }
}

