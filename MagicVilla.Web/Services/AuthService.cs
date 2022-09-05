using MagicVilla.Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Authentications;
using MagicVilla.Web.Services.IServices;

namespace MagicVilla.Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public Task<T> LoginAsync<T>(LogonRequestModel requestModel)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.POST,
                Data = requestModel,
                Uri = GetApi("LogonApi", _configuration)
            });
        }

        public Task<T> RegisterAsync<T>(Users newUser)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.POST,
                Data = newUser,
                Uri = GetApi("RegisterApi", _configuration)
            });
        }

        private string? GetApi(string apiResource, IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(apiResource))
                return null;

            return configuration.GetValue<string>("ServiceUrls:" + apiResource);
        }
    }
}