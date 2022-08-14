using MagicVilla.Service.Data;
using MagicVilla.Service.Models.Villa;
using MagicVilla.Service.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla.Service.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public VillaModel Get(Expression<Func<VillaModel, bool>> filter = null, bool tracked = true)
        {
            IQueryable<VillaModel> entities = _context.Villa;

            if (!tracked)
                entities = entities.AsNoTracking();

            if (filter != null)
                entities = entities.Where(filter);

            return entities.FirstOrDefault();
        }

        public List<VillaModel> GetAll(Expression<Func<VillaModel, bool>> filter = null)
        {
            IQueryable<VillaModel> entities = _context.Villa;

            if (filter != null)
                entities = entities.Where(filter);

            return entities.ToList();
        }

        public void Create(VillaModel villa)
        {
            _context.Villa.Add(villa);
            Save();
        }

        public void Update(VillaModel villa)
        {
            _context.Villa.Update(villa);
            Save();
        }

        public void Remove(VillaModel villa)
        {
            _context.Remove(villa);
            Save();
        }

        public void Save() => _context.SaveChanges();
    }
}
