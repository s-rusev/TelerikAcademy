using System;
using System.Linq;

class CorrectBrackets
{
    public static bool CheckBrackets(string input)
    {
        int counter = 0;
        foreach (char letter in input)
        {
            if (counter<0)
            {
                break;
            }
            if (letter == '(')
            {
                counter++;
            }
            else if (letter == ')')
            {
                counter--;
            }

        }
        if (counter != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        bool areBracketsCorrect = CheckBrackets(input);
        Console.WriteLine("Are the brackets correct? - {0}" , areBracketsCorrect);
    }


}

