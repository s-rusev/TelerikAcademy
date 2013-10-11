using System;

namespace ConsoleHero
{
    public class SampleSong : Song
    {
        public void PlaySong()
        {
            base.Play();
        }

        public SampleSong(string songText)
        {
            Note[] notes = SongGenerator.GetNotes(songText); //@"..\..\SongTextNazadNazadMomeKalino.txt"
            base.Notes = notes;
        }

    }
}