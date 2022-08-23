using MagicVilla.Service.Models.VillaNumber;

namespace MagicVilla.Service.Repository
{
    public interface IVillaNumberRepository : IRepository<VillaNumberModel>
    {
        public VillaNumberModel Update(VillaNumberModel entity);
    }
}
