using MagicVilla.Service.Models.VillaNumber;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Service.Repository
{
    public interface IVillaNumberRepository : IRepository<VillaNumberModel>
    {
        public VillaNumberModel Update(VillaNumberModel entity); 
    }
}
