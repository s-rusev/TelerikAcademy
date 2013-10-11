using System;
using System.Text;

class ASCIIprint
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        for (int i = 0; i < 127; i++)
        {
            char ASCIIChar = (char)i;
            Console.WriteLine("Character: " + ASCIIChar + " Code: " + i);
        }
    }
}
