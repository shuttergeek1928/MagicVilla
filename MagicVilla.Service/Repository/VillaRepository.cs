using MagicVilla.Service.Data;
using MagicVilla.Service.Models.Villa;

namespace MagicVilla.Service.Repository
{
    public class VillaRepository : Repository<VillaModel>, IVillaRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public VillaModel Update(VillaModel villa)
        {
            villa.LastUpdate = DateTime.Now;

            _context.Villa.Update(villa);
            Save();
            return villa;
        }
        public void Save() => _context.SaveChanges();
    }
}
