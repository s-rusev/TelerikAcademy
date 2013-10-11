using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShapesSurface
{
    class ShapeTest
    {
        static void Main()
        {
            Shape triangle = new Triangle(2.0 , 3.0);
            Shape rectangle = new Rectangle(5.0, 6.0);
            Shape circle = new Circle(3.0);
            Shape[] shapes = {triangle, rectangle , circle };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }

        }
    }
}
