using System;
using System.Linq;
using System.Text.RegularExpressions;

class ReplaceUppercaseTags
{
    public static string ConcertToUpperCase(string input)
    {
        string result = "";
        result = Regex.Replace(input, "<upcase>(.*?)</upcase>", m => m.Groups[1].Value.ToUpper());
        return result;
    }

    static void Main()
    {
        string input = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine(ConcertToUpperCase(input));
    }


}

