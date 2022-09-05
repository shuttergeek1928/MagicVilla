using MagicVilla.Web.Models.Villa;

namespace MagicVilla.Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Guid id, string token);
        Task<T> CreateAsync<T>(VillaCreateModel villaCreateModel, string token);
        Task<T> UpdateAsync<T>(Guid id, VillaUpdateModel villaUpdateModel, string token);
        Task<T> DeleteAsync<T>(Guid id, string token);
    }
}
