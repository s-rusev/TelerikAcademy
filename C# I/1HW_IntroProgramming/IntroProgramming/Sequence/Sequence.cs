using System;

class Sequence
{
    static void Main()
    {
        for (int i = 2; i < 12; i+=2)
        {
            Console.Write("{0} {1} ", i , (-1)*(i + 1));
        }
    }
}
