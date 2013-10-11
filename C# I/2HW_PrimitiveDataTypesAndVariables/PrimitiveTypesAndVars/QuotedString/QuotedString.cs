using System;

namespace QuotedString
{
    class QuotedString
    {
        static void Main()
        {
            string quotedStr = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(quotedStr);
            string notQuotedStr = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(notQuotedStr);
        }
    }
}

