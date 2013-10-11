using System;

class NthBitNumber
{
    static void Main()
    {
        Console.WriteLine("Enter bit position:");
        int position = Int16.Parse(Console.ReadLine());
        Console.WriteLine("Enter number: ");
        int n = Int16.Parse(Console.ReadLine());
        int i = 1;
        int mask = i << position;
        Console.WriteLine("Is the {0}-th bit of {1} 1? - {2}", position, n , (n & mask) == 0 ? false : true);
        // for the next task (11) we simply change false and true with 0 and 1 
    }
}

