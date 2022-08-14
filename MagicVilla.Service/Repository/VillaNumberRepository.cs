using MagicVilla.Service.Data;
using MagicVilla.Service.Models.VillaNumber;
using MagicVilla.Service.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Service.Repository
{
    public class VillaNumberRepository : Repository<VillaNumberModel>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public VillaNumberModel Update(VillaNumberModel entity)
        {
            entity.LastUpdated = DateTime.Now;

            _context.Update(entity);
            
            _context.SaveChanges();

            return entity;
        }
    }
}
