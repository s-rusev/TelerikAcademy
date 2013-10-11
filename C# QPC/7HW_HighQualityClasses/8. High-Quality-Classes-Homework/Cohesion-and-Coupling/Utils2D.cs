namespace CohesionAndCoupling
{
    using System;

    public static class Utils2D
    {
        public static double CalcDistance2D(Point2D firstPoint, Point2D secondPoint)
        {
            double x1 = firstPoint.Width;
            double y1 = firstPoint.Height;
           
            double x2 = secondPoint.Width;
            double y2 = secondPoint.Height;
         
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
    }
}
