namespace CohesionAndCoupling
{
    using System;

    public class Point2D
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Point2D(double width, double height) 
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
