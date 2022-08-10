using MagicVilla.Service.Models.Villa;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Service.Data.DataSeeders
{
    public class SeedVillaData
    {
        private static ApplicationDbContext _context;
        public SeedVillaData(ApplicationDbContext context)
        {
            _context = context;
        }

        public static async Task InitializeData()
        {
            await EnsureSeedData();
        }

        private static async Task<bool> EnsureSeedData()
        {
            var data = _context.Villa.Count();

            if (data != 0)
                return true;

            var villa = new VillaModel()
            {
                Id = Guid.NewGuid(),
                Name = "Bliss View",
                Details = "Unmatched authentic luxury.",
                Rate = 500.00M,
                Area = 750.00M,
                Occupancy = 5,
                Amenities = "Pool, Gym, Bar",
                ImageUrl = "",
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now
            };

            _context.Villa.Add(villa);

            await _context.SaveChangesAsync();

            return false;
        }
    }
}
