using System.Linq.Expressions;

namespace MagicVilla.Service.Repository
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        public T Get(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        public void Create(T entity);
        public void Remove(T entity);
        public void Save();
    }
}
