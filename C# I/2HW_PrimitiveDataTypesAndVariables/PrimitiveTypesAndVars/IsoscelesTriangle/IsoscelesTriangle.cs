using System;
using System.Text;

namespace IsoscelesTriangle
{
    public class IsoscelesTriangle
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            char copyrightChar = (char)169;
            Console.WriteLine("  " + copyrightChar + "  ");
            Console.WriteLine(" " + new string(copyrightChar, 3) + " ");
            Console.WriteLine(new string(copyrightChar, 5));
        }
    }
}

