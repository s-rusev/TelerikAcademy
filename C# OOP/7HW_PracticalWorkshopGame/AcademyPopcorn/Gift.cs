using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";
        private bool colidedWithRocket = false;
        private bool colidedWithBullet = false;

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '(', 'G', ')' } }, new MatrixCoords(1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var collisionItem in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (collisionItem.Equals(Racket.CollisionGroupString))
                {
                    colidedWithRocket = true;
                    this.IsDestroyed = true;
                }
                else if (collisionItem.Equals(Bullet.CollisionGroupString))
                {
                    colidedWithBullet = true;
                    this.IsDestroyed = true;
                }

            }
            
        }


        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            if (colidedWithRocket)
            {
                producedObjects.Add(new ShootingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 3), 6));
            }
            return producedObjects;
        }
    }
}