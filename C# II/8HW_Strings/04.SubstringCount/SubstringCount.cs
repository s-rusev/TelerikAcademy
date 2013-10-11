using System;
using System.Linq;

class SubstringCount
{

    private static int FindSubstringCount(string input, string substring)
    {
        int count = 0;
        int index = 0;
        while ((index = input.IndexOf(substring, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            index++;
            count++;
        }
        return count;
    }

    static void Main()
    {
        string input = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string substring = "in";
        Console.WriteLine(FindSubstringCount(input, substring));
    }

    
}

