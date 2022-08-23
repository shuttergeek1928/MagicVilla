using MagicVilla.Web.Models.Villa;

namespace MagicVilla.Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(Guid id);
        Task<T> CreateAsync<T>(VillaCreateModel villaCreateModel);
        Task<T> UpdateAsync<T>(Guid id, VillaUpdateModel villaUpdateModel);
        Task<T> DeleteAsync<T>(Guid id);
    }
}
