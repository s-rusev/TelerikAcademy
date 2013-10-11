using System;

class BonusScores
{
    static void Main()
    {
        Console.WriteLine("Enter a number between 1 and 9: ");
        byte n;
        if (!byte.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Wrong input!");
        }
        else
        {
            switch (n)
            {
                case 1:
                    Console.WriteLine(n * 10);
                    break;
                case 2:
                    Console.WriteLine(n * 10);
                    break;
                case 3:
                    Console.WriteLine(n * 10);
                    break;
                case 4:
                    Console.WriteLine(n * 100);
                    break;
                case 5:
                    Console.WriteLine(n * 100);
                    break;
                case 6:
                    Console.WriteLine(n * 100);
                    break;
                case 7:
                    Console.WriteLine(n * 1000);
                    break;
                case 8:
                    Console.WriteLine(n * 1000);
                    break;
                case 9:
                    Console.WriteLine(n * 1000);
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
        }
    }
}
