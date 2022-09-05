using MagicVilla.Web.Models.VillaNumber;

namespace MagicVilla.Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>(string token, string? includeChildProp = null);
        Task<T> GetAsync<T>(string token, int villaNumber, string? includeChildProp = null);
        Task<T> CreateAsync<T>(VillaNumberCreateModel villaNumberCreateModel, string token);
        Task<T> UpdateAsync<T>(int villaNumber, VillaNumberUpdateModel villaNumberUpdateModel, string token);
        Task<T> DeleteAsync<T>(int villaNumber, string token);
    }
}
