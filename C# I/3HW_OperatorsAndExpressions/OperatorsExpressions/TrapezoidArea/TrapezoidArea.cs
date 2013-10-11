using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Enter first side of trapezoid: ");
        double sideA = Double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second side of trapezoid: ");
        double sideB = Double.Parse(Console.ReadLine());
        Console.WriteLine("Enter height of trapezoid: ");
        double height = Double.Parse(Console.ReadLine());
        Console.WriteLine("The area of the trapezoid is {0} ", (sideA+sideB) * height/2);
    }
}

