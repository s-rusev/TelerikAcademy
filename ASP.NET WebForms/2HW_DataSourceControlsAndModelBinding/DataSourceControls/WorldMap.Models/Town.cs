using System.ComponentModel.DataAnnotations;

namespace WorldMap.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Population { get; set; }

        public virtual Country Country { get; set; }
    }
}