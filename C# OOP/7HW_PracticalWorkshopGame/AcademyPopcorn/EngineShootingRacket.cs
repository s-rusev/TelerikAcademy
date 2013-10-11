using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class EngineShootingRocket : Engine
    {
        public EngineShootingRocket(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
            
        }
    }
}