﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.Villa
{
    public class VillaUpdateModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Details { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public decimal Area { get; set; }

        [Required]
        public int Occupancy { get; set; }
        public string Amenities { get; set; }
        public string ImageUrl { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
