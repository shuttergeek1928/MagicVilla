using MagicVilla.Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla.Service.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        internal DbSet<T> _DbContext;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _DbContext = _context.Set<T>();

        }

        public T Get(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> entities = _DbContext;

            if (!tracked)
                entities = entities.AsNoTracking();

            if (filter != null)
                entities = entities.Where(filter);

            return entities.FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> entities = _DbContext;

            if (filter != null)
                entities = entities.Where(filter);

            return entities.ToList();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public void Save() => _context.SaveChanges();

    }
}
