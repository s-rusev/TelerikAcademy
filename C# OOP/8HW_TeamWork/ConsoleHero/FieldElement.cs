using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHero
{
    public class FieldElement : GameObject
    {
    //    public const char Symbol = '|';

        public FieldElement(MatrixCoords upperLeft , char[,] symbolChars)
            : base(upperLeft , symbolChars)
        {
           // new char[,]{{'|'}};
            this.body[0, 0] = symbolChars[0, 0];
         //   this.body[0, 0] = FieldElement.Symbol;
        }    
        public override void Update()
        {
            
        }
    
    }
}
