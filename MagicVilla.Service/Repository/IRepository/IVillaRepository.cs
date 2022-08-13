using MagicVilla.Service.Models.Villa;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MagicVilla.Service.Repository.IRepository
{
    public interface IVillaRepository
    {
        public ActionResult<List<VillaModel>> GetAll(Expression<Func<VillaModel, bool>> filter = null);
        public ActionResult<VillaModel> Get(Expression<Func<VillaModel, bool>> filter = null, bool tracked = true);
        public void Create(VillaModel villa);
        public void Remove(VillaModel villa);
        public void Save();
    }
}
