using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Web.Models.VillaNumber
{
    public class VillaNumberCreateModel
    {
        [Required]
        public int VillaNumber { get; set; }

        [Required]
        public Guid VillaId { get; set; }

        [Required]
        public string SpecialDetails { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
