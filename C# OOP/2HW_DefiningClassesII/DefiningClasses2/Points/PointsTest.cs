using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class PointsTest
    {
        static void Main(string[] args)
        {
            Point3D first = new Point3D();
            Console.WriteLine(first.ToString());
            Point3D second = new Point3D(1, 1, 1);
            Console.WriteLine(second.ToString());
            Console.WriteLine("The distance between the two points is:" + DistanceCalculation.CalculateDistance(first,second));
            Path loadedPath = new Path();
            string pathLoadFile = @"..\..\path.txt";
            loadedPath = PathStorage.LoadFile(pathLoadFile);
            Console.WriteLine(loadedPath.ToString());
            string pathSaveFile = @"../../outputPath.txt";
            PathStorage.SaveFile(pathSaveFile, loadedPath);
        }
    }
}
