using System;

namespace ConsoleHero
{
    public abstract class Song : IPlayable
    {
        private Note[] notes;

        public Note[] Notes
        {
            get
            {
                return this.notes;
            }
            set
            {
                this.notes = value;
            }
        }


        public void Play()
        {
            foreach (Note note in notes)
            {
                if (note.NoteTone == NoteFrequencyToneEnum.Rest)
                {
                    //do nothing
                    // Thread.Sleep((int)note.NoteDuration);
                }
                else
                {
                    Console.Beep((int)note.NoteTone, (int)note.NoteDuration);
                }
            }
        }
    }
}
