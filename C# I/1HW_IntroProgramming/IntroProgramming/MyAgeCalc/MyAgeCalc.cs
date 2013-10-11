using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your age: ");
        string input = Console.ReadLine();
        int n = int.Parse();
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid age!"); 
        }
        Console.WriteLine("Your age after 10 years will be: " + (n + 10));
    }
}
