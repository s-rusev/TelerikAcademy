using System;

class SetNthBit
{
    static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int n = Int16.Parse(Console.ReadLine());
        Console.WriteLine("Enter desired position of bit to set: ");
        int position = Int16.Parse(Console.ReadLine());
        Console.WriteLine("Enter the bit value: ");
        int setBitTo = Int16.Parse(Console.ReadLine()); //0 or 1
        int i = 1;
        int mask = i << position;
        if (setBitTo == 1)
        {
            n = n | mask;
            Console.WriteLine(n);
            
        }
        else 
        {
            n = n & (~mask);
            Console.WriteLine(n);
        }
    }
}

