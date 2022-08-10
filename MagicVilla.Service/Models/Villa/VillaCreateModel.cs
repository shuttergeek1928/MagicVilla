using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.Villa
{
    public class VillaCreateModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
