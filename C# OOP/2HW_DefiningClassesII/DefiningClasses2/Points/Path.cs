using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public List<Point3D> Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var point in this.points)
            {
                sb.Append(point.ToString()).Append('\n');
            }
            return sb.ToString();
        }
    }
}
