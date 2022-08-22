using MagicVilla.Web.Models.Villa;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Web.Models.VillaNumber
{
    public class VillaNumberViewModel
    {
        [Required]
        public int VillaNumber { get; set; }
        public string SpecialDetails { get; set; }
        public VillaModel Villa { get; set; }
    }
}
