using MagicVilla.Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.VillaNumber;
using MagicVilla.Web.Services.IServices;

namespace MagicVilla.Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiResource;

        public VillaNumberService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _configuration = configuration;
            _apiResource = "VillaNumberApi";
        }

        public Task<T> CreateAsync<T>(VillaNumberCreateModel villaNumberCreateModel)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.POST,
                Data = villaNumberCreateModel,
                Uri = GetApi(_apiResource, _configuration)
            });
        }

        public Task<T> DeleteAsync<T>(int villaNumber)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.DELETE,
                Uri = GetApi(_apiResource, _configuration, villaNumber)
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.GET,
                Uri = GetApi(_apiResource, _configuration)
            });
        }

        public Task<T> GetAsync<T>(int villaNumber)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.GET,
                Uri = GetApi(_apiResource, _configuration, villaNumber)
            });

        }

        public Task<T> UpdateAsync<T>(int villaNumber, VillaNumberUpdateModel villaNumberUpdateModel)
        {
            return SendApiRequestAsync<T>(new APIRequest
            {
                ApiType = ApiTypes.ApiType.PUT,
                Data = villaNumberUpdateModel,
                Uri = GetApi(_apiResource, _configuration, villaNumber, ApiTypes.ApiType.PUT)
            });
        }

        public string GetApi(string resource, IConfiguration configuration, int? villaNumber = 0, ApiTypes.ApiType apiType = ApiTypes.ApiType.GET)
        {
            if(villaNumber != null && villaNumber != 0)
            {
                if(apiType != ApiTypes.ApiType.PUT)
                    return configuration.GetValue<string>("ServiceUrls:" + resource) + $"/{villaNumber}";

                return configuration.GetValue<string>("ServiceUrls:" + resource) + $"?villaNumber={villaNumber}";
            }

            return configuration.GetValue<string>("ServiceUrls:" + resource);
        }
    }
}