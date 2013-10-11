namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentException("Sides of rectangle must be positive!");
            }
            this.Width = width;
            this.Height = height;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

    }
}
