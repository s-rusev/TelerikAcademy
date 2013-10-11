using System;

class OddEvenNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int n = Int16.Parse(Console.ReadLine());
        if (n % 2 == 0)
        {
            Console.WriteLine("Number is even ");
        }
        else 
        {
            Console.WriteLine("Number is odd");
        }
    }
}

