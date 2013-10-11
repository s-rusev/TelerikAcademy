using System;

namespace StringConcat
{
    public class StringConcat
    {
        static void Main()
        {
            string firstStr = "Hello";
            string secondStr = "World";
            object concatStr = null;
            concatStr = firstStr + " " + secondStr;
            Console.WriteLine(concatStr);
            string objToStr = null;
            objToStr = (string)concatStr;
            Console.WriteLine(objToStr);
        }
    }
}

