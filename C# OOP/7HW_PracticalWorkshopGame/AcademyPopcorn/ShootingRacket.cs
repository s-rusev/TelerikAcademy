using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  
    public class ShootingRacket : Racket
    {
        private bool isShooting = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }
        public void Shoot()
        {
            isShooting = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (isShooting)
            {
                isShooting = false;
                produceObjects.Add(new Bullet(this.topLeft + new MatrixCoords(-1,0)));
                produceObjects.Add(new Bullet(this.topLeft + new MatrixCoords(-1 , this.Width - 1)));
            }
            return produceObjects;
        }
    }
}