using System;

class NumberToDecHexPercentAndSci
{
    static void Main()
    {
        Console.WriteLine("A program that reads a number and prints its decimal, hexadecimal, percantage and scientific notations.");
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Decimal representation: {0,15}", number);  
        Console.WriteLine("Hexadecimal representation: {0,15:X}", number); 
        Console.WriteLine("Percentage: {0,15:P}", number); 
        Console.WriteLine("Scientific: {0,15:E}", number); 
    }
}
