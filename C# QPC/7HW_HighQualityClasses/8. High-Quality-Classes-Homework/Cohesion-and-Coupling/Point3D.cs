namespace CohesionAndCoupling
{
    using System;

    public class Point3D
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        
        public Point3D(double width, double height, double depth) 
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }
    }
}
