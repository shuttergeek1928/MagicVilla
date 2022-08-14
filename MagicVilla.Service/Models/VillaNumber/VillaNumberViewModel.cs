using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Service.Models.VillaNumber
{
    public class VillaNumberViewModel
    {
        [Required]
        public int VillaNumber { get; set; }
        public string SpecialDetails { get; set; }
    }
}
