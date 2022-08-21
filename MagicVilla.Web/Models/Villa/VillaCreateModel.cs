using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Web.Models.Villa
{
    public class VillaCreateModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Details { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public decimal Area { get; set; }

        [Required]
        public int Occupancy { get; set; }
        public string? Amenities { get; set; }
        public string? ImageUrl { get; set; }
    }
}
