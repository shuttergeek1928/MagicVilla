using MagicVilla.Web.Models.VillaNumber;

namespace MagicVilla.Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>(string? includeChildProp = null);
        Task<T> GetAsync<T>(int villaNumber, string? includeChildProp = null);
        Task<T> CreateAsync<T>(VillaNumberCreateModel villaNumberCreateModel);
        Task<T> UpdateAsync<T>(int villaNumber, VillaNumberUpdateModel villaNumberUpdateModel);
        Task<T> DeleteAsync<T>(int villaNumber);
    }
}
