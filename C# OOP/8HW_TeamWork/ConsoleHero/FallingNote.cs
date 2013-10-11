using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHero
{
    public class FallingNote : MovingObject
    {
        private Note note;

        //public FallingNote(MatrixCoords topLeft , char noteChar)
        //    : base(topLeft, new char[,] { { noteChar } } , new MatrixCoords(1,0))
        //{
        //}

        public FallingNote(MatrixCoords topLeft, char[,] noteChars, Note note)
            : base(topLeft, noteChars, new MatrixCoords(1, 0))
        {
            this.note = new Note(note.NoteTone, note.NoteDuration);
        }

        public Note Note
        {
            get
            {
                return this.note;
            }
            set
            {
                this.note = value;
            }
        }

        public void Update()
        {
            base.Update();
        }

    }
}
