using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public static class DistanceCalculation
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint) 
        {
            double distance = 0.0;
            double deltaX = secondPoint.XCoord  - firstPoint.XCoord;
            double deltaY = secondPoint.YCoord  - firstPoint.YCoord;
            double deltaZ = secondPoint.ZCoord  - firstPoint.ZCoord;
            distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return distance;
        }

    }
}
