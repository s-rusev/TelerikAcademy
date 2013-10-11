using System;

class CircleAreaPerimeter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());
        Console.WriteLine("The area of the circle is: {0:0.0000}",(Math.PI*Math.Pow(radius,2)));
        Console.WriteLine("The perimeter of the circle is {0:0.0000}", (2*Math.PI*radius));
    }
}

