using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHero
{
    class FallingNoteBonus : FallingNote
    {
        public FallingNoteBonus(MatrixCoords topLeft, Note note) :
            base(topLeft, new char[,] { { '(', '*', ')' } }, note)
        {
        }

    }
}