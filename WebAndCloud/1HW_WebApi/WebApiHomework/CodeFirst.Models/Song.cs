namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;

    public class Song
    {
        private ICollection<Album> albums;
        private ICollection<Artist> artists;

        public Song()
        {
            this.albums = new HashSet<Album>();
            this.artists = new HashSet<Artist>();
        }

        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Genre { get; set; }
        
        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }
            set
            {
                this.artists = value;
            }
        }
    }
}