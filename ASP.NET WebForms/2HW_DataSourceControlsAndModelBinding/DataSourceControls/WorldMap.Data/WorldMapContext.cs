using System;
using System.Data.Entity;
using System.Linq;
using WorldMap.Models;

namespace WorldMap.Data
{
    public class WorldMapContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Town> Towns { get; set; }

        public WorldMapContext()
            : base("WorldMapContext")
        {
        }
    }
}
