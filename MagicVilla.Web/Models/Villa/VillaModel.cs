using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.Villa
{
    public class VillaModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Rate { get; set; }
        public decimal Area { get; set; }
        public int Occupancy { get; set; }
        public string Amenities { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
