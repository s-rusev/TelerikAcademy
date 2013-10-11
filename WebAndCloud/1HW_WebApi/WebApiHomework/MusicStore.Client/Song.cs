namespace MusicStore.Client
{
    using System;

    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Genre { get; set; }
    }
}