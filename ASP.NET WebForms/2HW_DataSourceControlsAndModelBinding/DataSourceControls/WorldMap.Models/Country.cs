using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldMap.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Language { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual IEnumerable<Town> Towns { get; set; }

        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
    }
}