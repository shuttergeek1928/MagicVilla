using System.Linq.Expressions;

namespace MagicVilla.Service.Repository
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeChildProperties = null);
        public T Get(Expression<Func<T, bool>>? filter = null, bool tracked = true, string? includeChildProperties = null);
        public void Create(T entity);
        public void Remove(T entity);
        public void Save();
    }
}
