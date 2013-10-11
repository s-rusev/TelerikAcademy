using System;

class QuadraticEquation
{
    public static void SolveQuadraticEquation(double a, double b, double c)
    {
        double d = b * b - 4 * a * c;
        double x, x1, x2;
        if (d > 0)
        {
            x1 = (-b + System.Math.Sqrt(d)) / (2 * a);
            x2 = (-b - System.Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("Two real solutions: {0,8:f4} and  {1,8:f4}", x1, x2);
        }
        else if (d < 0)
        {
            Console.WriteLine("No real solutions");
        }
            else
            {
                x = (-b + System.Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("One Real Solution: {0,8:f4}", x);
            }
    }
 
    static void Main()
    {
        Console.WriteLine("Enter the coefficients a, b, c: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        SolveQuadraticEquation(a, b, c);
    }
}

