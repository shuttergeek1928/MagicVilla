using MagicVilla.Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Villa;
using MagicVilla.Web.Services.IServices;

namespace MagicVilla.Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public Task<T> CreateAsync<T>(VillaCreateModel villaCreateModel, string token)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.POST,
                Data = villaCreateModel,
                Uri = GetApi("VillaApi", _configuration),
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(Guid id, string token)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.DELETE,
                Uri = GetApi("VillaApi", _configuration, id),
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.GET,
                Uri = GetApi("VillaApi", _configuration),
                Token = token
            });
        }

        public Task<T> GetAsync<T>(Guid id, string token)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.GET,
                Uri = GetApi("VillaApi", _configuration, id),
                Token = token
            });

        }

        public Task<T> UpdateAsync<T>(Guid id, VillaUpdateModel villaUpdateModel, string token)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.PUT,
                Data = villaUpdateModel,
                Uri = GetApi("VillaApi", _configuration, id, ApiTypes.ApiType.PUT),
                Token = token
            });
        }

        public string GetApi(string resource, IConfiguration configuration, Guid? id = (Guid?)null, ApiTypes.ApiType apiType = ApiTypes.ApiType.GET)
        {
            if (id != null && id != Guid.Empty)
            {
                if (apiType != ApiTypes.ApiType.PUT)
                    return configuration.GetValue<string>("ServiceUrls:" + resource) + $"/{id}";

                return configuration.GetValue<string>("ServiceUrls:" + resource) + $"?id={id}";
            }

            return configuration.GetValue<string>("ServiceUrls:" + resource);
        }
    }
}