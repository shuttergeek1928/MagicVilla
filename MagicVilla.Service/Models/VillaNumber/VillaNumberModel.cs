using MagicVilla.Service.Models.Villa;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Service.Models.VillaNumber
{
    public class VillaNumberModel
    {
        [ForeignKey("Villa")]
        public Guid VillaId { get; set; }

        public VillaModel Villa { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNumber { get; set; }

        [Required]
        public string SpecialDetails { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
