using System;

//Write a method ReadNumber(int start, int end) that enters an integer number
//in given range [start…end]. If an invalid number or non-number text is entered, 
//the method should throw an exception. Using this method write a program that enters 10 numbers:
//            a1, a2, … a10, such that 1 < a1 < … < a10 < 100

class ReadNumbers
{
    static int ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();
        try
        {
            int number = Int32.Parse(input);
            if (number < start || number > end)
            {
                throw new Exception("Number out of range!");
            }
            return number;
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
            return start;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return start;
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter a number in [1,100]");
        int n = ReadNumber(1, 100);
        Console.WriteLine(n);
        for (int i = 0; i < 9; i++)
        {
            int num = n; 
            Console.WriteLine("Enter a number in [{0},100]", num);
            num = ReadNumber(n,100);
            n = num;
        }

    }
}
