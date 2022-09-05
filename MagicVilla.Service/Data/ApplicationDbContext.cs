using MagicVilla.Service.Models.Authentications;
using MagicVilla.Service.Models.Villa;
using MagicVilla.Service.Models.VillaNumber;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<VillaModel> Villa { get; set; }
        public DbSet<VillaNumberModel> VillaNumber { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VillaModel>().HasData(
                new VillaModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bliss View",
                    Details = "Unmatched authentic luxury.",
                    Rate = 500.00M,
                    Area = 750.00M,
                    Occupancy = 5,
                    Amenities = "Pool, Gym, Bar",
                    ImageUrl = "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1",
                    CreatedDate = DateTime.Now,
                    LastUpdate = DateTime.Now
                },
                new VillaModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mountain View",
                    Details = "Moment Creating.",
                    Rate = 1000.00M,
                    Area = 1000.00M,
                    Occupancy = 3,
                    Amenities = "Pool, Gym, Bar",
                    ImageUrl = "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1",
                    CreatedDate = DateTime.Now,
                    LastUpdate = DateTime.Now
                }
                );

            modelBuilder.Entity<VillaNumberModel>().HasData(
                new VillaNumberModel()
                {
                    VillaNumber = 1,
                    SpecialDetails = "Luxury.",
                    CreatedDate = DateTime.Now,
                    LastUpdated = DateTime.Now
                }
                );
        }
    }
}