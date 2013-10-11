using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WorldMap.Models
{
    public class Continent
    {
        [Key]
        public int ContinentId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Country> Countries { get; set; }

        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }
    }
}
