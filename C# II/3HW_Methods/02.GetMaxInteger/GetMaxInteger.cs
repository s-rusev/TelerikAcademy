using System;

//Write a method GetMax() with two parameters that returns the bigger of two integers.
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

class GetMaxInteger
{
    static int GetMax(int first, int second) 
    {
        return Math.Max(first, second);
    }
    static void MaxThreeInts() 
    {
        Console.WriteLine("Enter three integers: ");
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());
        int temp = GetMax(first, second);
        int result = GetMax(temp, third);
        Console.WriteLine("The biggest integer is: {0}", result);
    }
    static void Main()
    {
        MaxThreeInts();
    }
}
