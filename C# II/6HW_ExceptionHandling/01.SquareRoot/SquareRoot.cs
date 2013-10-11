using System;

class SquareRoot
{
    static void Main()
    {
        string input = Console.ReadLine();
        try
        {
            int number = Int32.Parse(input);
            if (number < 0)
            {
                throw new Exception("Input number must be positive!");
            }
            Console.WriteLine(Math.Sqrt(number));
        }
        catch (OverflowException)
        {
            Console.WriteLine("Too big number for Int32.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }

    }
}

