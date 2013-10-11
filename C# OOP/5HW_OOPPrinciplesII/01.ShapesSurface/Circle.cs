using System;

namespace _01.ShapesSurface
{
    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius cannot be negative!");
                }
                this.radius = value;
            }
        }

        public Circle(double radius) : base(radius , radius)
        {
            this.Radius = radius;
        }


        public override double CalculateSurface()
        {
            return (Math.PI * radius * radius);    
        }
    }
}