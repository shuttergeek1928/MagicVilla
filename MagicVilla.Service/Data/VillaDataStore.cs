﻿using MagicVilla.Service.Models.Villa;

namespace MagicVilla.Service.Data
{
    public static class VillaDataStore
    {
        public static IList<VillaDTO> villaList=  new List<VillaDTO>
            {
                new VillaDTO{ Id = new Guid("1dc4eaf5-4f06-4e50-a49e-cd3a66b496f5"), Name = "Pool View"},
                new VillaDTO{ Id = new Guid("1dc4eaf5-4f06-4e50-a49e-cd3a66b496f0"), Name = "Beach View"}
            };
    }
}
