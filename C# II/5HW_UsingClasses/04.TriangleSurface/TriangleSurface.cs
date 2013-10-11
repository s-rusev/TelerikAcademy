using System;

class TriangleSurface
{
    static void Main()
    {
        Console.WriteLine("Enter a side of a triangle and altitude to it: ");
        double a = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        Console.WriteLine("The surface of the triangle is: {0:0.000}", ((a * h) / 2.0));
        Console.WriteLine("Enter three sides of a triangle: ");
        double m = double.Parse(Console.ReadLine());
        double n = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());
        double per = (m + n + p) / 2.0;
        double surface = Math.Sqrt(per * (per - m) * (per - n) * (per - p));
        Console.WriteLine("The surface of the triangle is: {0:0.000}", surface);
        Console.WriteLine("Enter two sides of a triangle and an angel between them: ");
        m = double.Parse(Console.ReadLine());
        n = double.Parse(Console.ReadLine());
        double angle = double.Parse(Console.ReadLine());
        surface = (m * n * Math.Sin(angle)) / 2.0;
        Console.WriteLine("The surface of the triangle is: {0:0.000}", surface);

    }
}
