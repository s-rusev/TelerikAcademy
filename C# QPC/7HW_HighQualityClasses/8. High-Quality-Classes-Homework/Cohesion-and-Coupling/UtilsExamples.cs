namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(UtilsFiles.GetFileExtension("example"));
            Console.WriteLine(UtilsFiles.GetFileExtension("example.pdf"));
            Console.WriteLine(UtilsFiles.GetFileExtension("example.new.pdf"));

            Console.WriteLine(UtilsFiles.GetFileNameWithoutExtension("example"));
            Console.WriteLine(UtilsFiles.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(UtilsFiles.GetFileNameWithoutExtension("example.new.pdf"));


            Point2D pointFirst2D = new Point2D(1, -2);
            Point2D pointSecond2D = new Point2D(3, 4);
            double distance2D = Utils2D.CalcDistance2D(pointFirst2D, pointSecond2D);
            Console.WriteLine("Distance in the 2D space = {0:f2}", distance2D);

            Point3D pointFirst3D = new Point3D(5, 2, -1);
            Point3D pointSecond3D = new Point3D(3, -6, 4);
            double distance3D = Utils3D.CalcDistance3D(pointFirst3D, pointSecond3D);
            Console.WriteLine("Distance in the 3D space = {0:f2}", distance3D);

            Console.WriteLine("Volume = {0:f2}", Utils3D.CalcVolume(pointFirst3D));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils3D.CalcDistFromZeroPointToAPoint(pointFirst3D));
            Console.WriteLine("Diagonal XY = {0:f2}", Utils3D.CalcDiagonalXY(pointFirst3D));
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils3D.CalcDiagonalXZ(pointFirst3D));
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils3D.CalcDiagonalYZ(pointFirst3D));
        }
    }
}
