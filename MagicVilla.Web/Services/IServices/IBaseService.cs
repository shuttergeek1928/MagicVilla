using MagicVilla.Web.Models;

namespace MagicVilla.Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse Response { get; set; }
        Task<T> SendApiRequestAsync<T>(APIRequest request);
    }
}
