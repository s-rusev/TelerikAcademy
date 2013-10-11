namespace CohesionAndCoupling
{
    using System;

    public static class Utils3D
    {
        public static double CalcDistance3D(Point3D firstPoint, Point3D secondPoint)
        {
            double x1 = firstPoint.Width;
            double y1 = firstPoint.Height;
            double z1 = firstPoint.Depth;

            double x2 = secondPoint.Width;
            double y2 = secondPoint.Height;
            double z2 = secondPoint.Depth;

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(Point3D point)
        {
            double width = point.Width;
            double height = point.Height;
            double depth = point.Depth;

            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDistFromZeroPointToAPoint(Point3D point)
        {
            double width = point.Width;
            double height = point.Height;
            double depth = point.Depth;

            double distance = CalcDistance3D(new Point3D(0, 0, 0), new Point3D(width, height, depth));
            return distance;
        }

        public static double CalcDiagonalXY(Point3D point)
        {
            double width = point.Width;
            double height = point.Height;

            double distance = CalcDistance3D(new Point3D(0, 0, 0), new Point3D(width, height, 0));
            return distance;
        }

        public static double CalcDiagonalXZ(Point3D point)
        {
            double width = point.Width;
            double depth = point.Depth;

            double distance = CalcDistance3D(new Point3D(0, 0, 0), new Point3D(width, 0, depth));
            return distance;
        }

        public static double CalcDiagonalYZ(Point3D point)
        {
            double height = point.Height;
            double depth = point.Depth;

            double distance = CalcDistance3D(new Point3D(0, 0, 0), new Point3D(0, height, depth));
            return distance;
        }
    }
}
