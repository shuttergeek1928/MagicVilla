using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.VillaNumber
{
    public class VillaNumberViewModel
    {
        [Required]
        public int VillaNumber { get; set; }
        public string SpecialDetails { get; set; }
    }
}
