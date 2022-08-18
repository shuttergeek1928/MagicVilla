using MagicVilla.Service.Models.Villa;

namespace MagicVilla.Service.Repository
{
    public interface IVillaRepository : IRepository<VillaModel>
    {
        public VillaModel Update(VillaModel villa);
    }
}
