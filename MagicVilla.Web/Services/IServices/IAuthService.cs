using MagicVilla.Web.Models.Authentications;

namespace MagicVilla.Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LogonRequestModel requestModel);
        Task<T> RegisterAsync<T>(Users newUser);
    }
}
