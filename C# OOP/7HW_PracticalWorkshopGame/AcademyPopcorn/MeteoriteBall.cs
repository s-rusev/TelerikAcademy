using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public int TrailLife { get; set; }
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.TrailLife = 3;
        }

        public override void Update()
        {
            base.Update();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> trail = new List<TrailObject>(); 
            trail.Add(new TrailObject(this.TopLeft, new char[,] { { '+' } }, 3));
            return trail;
        }
    }
}