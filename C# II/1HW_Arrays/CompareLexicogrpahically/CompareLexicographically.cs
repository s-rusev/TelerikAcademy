using System;

//Write a program that compares two char arrays lexicographically (letter by letter).


class CompareLexicographically
{
    static void Main()
    {
        Console.WriteLine("Program to compare two char arrays lexicographically: ");
        Console.WriteLine("Enter two char arrays: ");
        string firstInput = Console.ReadLine();
        string secondInput = Console.ReadLine();
        int res = firstInput.CompareTo(secondInput);
        if (res < 0)
        {
            Console.WriteLine("First char array is lexicographically before the other!");
        }
        else if (res > 0)
        {
            Console.WriteLine("First char array is lexicographically after the other!");
        }
        else
        {
            Console.WriteLine("The char arrays are equal!");
        }
    }
}
