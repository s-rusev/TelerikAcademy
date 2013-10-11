using System;

class RandomNumbers
{
    static void Main()
    {
        Random rand = new Random();
        Console.WriteLine("Printing 10 random numbers between 100 and 200: ");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(rand.Next(100, 201));
        }
    }
}
