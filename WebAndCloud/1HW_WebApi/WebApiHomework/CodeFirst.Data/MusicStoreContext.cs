namespace CodeFirst.Data
{
    using System;
    using System.Data.Entity;
    using CodeFirst.Models;

    public class MusicStoreContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        public MusicStoreContext()
            : base("MusicStoreDb")
        {
        }
    }
}
