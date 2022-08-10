using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.Villa
{
    public class VillaDTO
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
