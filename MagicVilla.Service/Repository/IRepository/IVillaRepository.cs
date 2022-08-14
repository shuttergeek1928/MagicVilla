using MagicVilla.Service.Models.Villa;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MagicVilla.Service.Repository
{ 
    public interface IVillaRepository
    {
        public List<VillaModel> GetAll(Expression<Func<VillaModel, bool>> filter = null);
        public VillaModel Get(Expression<Func<VillaModel, bool>> filter = null, bool tracked = true);
        public void Create(VillaModel villa);
        public void Update(VillaModel villa);
        public void Remove(VillaModel villa);
        public void Save();
    }
}
