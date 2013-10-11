using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Points
{
    public struct Point3D
    {
        private double xCoord;
        private double yCoord;
        private double zCoord;
        private static readonly Point3D pointZero = new Point3D(0.0, 0.0, 0.0);

        public Point3D(double x = 0.0, double y = 0.0, double z = 0.0) : this()
        {
            this.XCoord = x; 
            this.YCoord = y;
            this.ZCoord = z;
        }

        public static Point3D PointZero
        {
            get
            {
                return pointZero;
            }
        }

        public double XCoord
        {
            get
            {
                return this.xCoord;
            }
            set
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    Exception up = new ArgumentOutOfRangeException("Number out of range");
                    throw up; //haha
                }
                this.xCoord = value;
            }
        }

        public double YCoord
        {
            get
            {
                return this.yCoord;
            }
            set
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new ArgumentOutOfRangeException("Number out of range");
                }
                this.yCoord = value;
            }
        }

        public double ZCoord
        {
            get
            {
                return this.zCoord;
            }
            set
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new ArgumentOutOfRangeException("Number out of range");
                }
                this.zCoord = value;
            }
        }

        public override string ToString()
        {
            return string.Format("xCoord: {0}, yCoord: {1}, zCoord: {2}", xCoord, yCoord, zCoord);
        }

    }
}
