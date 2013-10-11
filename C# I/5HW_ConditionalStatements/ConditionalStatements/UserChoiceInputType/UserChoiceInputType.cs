using System;

class UserChoiceInputType
{
    static void Main()
    {
        Console.WriteLine("Enter 1 for int, 2 for double, 3 for string");
        byte choice = byte.Parse(Console.ReadLine());
        switch (choice) 
        {
            case 1:
                Console.WriteLine("Enter an integer: ");
                int numInt = int.Parse(Console.ReadLine());
                numInt++;
                Console.WriteLine(numInt);
                break;
            case 2:
                Console.WriteLine("Enter a double: ");
                double numDouble = double.Parse(Console.ReadLine());
                numDouble++;
                Console.WriteLine(numDouble);
                break;
            case 3:
                Console.WriteLine("Enter a string: ");
                string input = Console.ReadLine();
                Console.WriteLine(input + "*");
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }
}

