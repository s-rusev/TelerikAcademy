namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;

        public Album()
        {
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
        }

        public Album CreateAlbum()
        {
            return new Album { Title = this.Title, Producer = this.Producer, Songs = this.Songs};
        }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public string Producer { get; set; }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }
            set
            {
                this.songs = value;
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
