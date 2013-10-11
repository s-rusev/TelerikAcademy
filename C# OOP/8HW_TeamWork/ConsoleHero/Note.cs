using System;

namespace ConsoleHero
{
    public class Note
    {
        readonly NoteFrequencyToneEnum noteFrequencyTone;
        readonly NoteDurationEnum noteDuration;

        public Note(NoteFrequencyToneEnum frequency, NoteDurationEnum time)
        {
            noteFrequencyTone = frequency;
            noteDuration = time;
        }

        public NoteFrequencyToneEnum NoteTone { get { return noteFrequencyTone; } }
        public NoteDurationEnum NoteDuration { get { return noteDuration; } }
    }
}
