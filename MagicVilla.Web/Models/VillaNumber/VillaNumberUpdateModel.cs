using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.VillaNumber
{
    public class VillaNumberUpdateModel
    {
        [Required]
        public int VillaNumber { get; set; }

        [Required]
        public Guid VillaId { get; set; }

        public string SpecialDetails { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
