using System;

class PrintAllNumbersToN
{
    static void Main()
    {
        int number;
        string input = Console.ReadLine();
        bool isValid = int.TryParse(input, out number);
        if (isValid)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            if (input == null) 
            {
                input = ""; 
            }
            Console.WriteLine("Attempted conversion of '{0}' failed.", input);
        }
    }
}

