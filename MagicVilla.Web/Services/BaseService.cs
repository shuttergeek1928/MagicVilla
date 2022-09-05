using MagicVilla.Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MagicVilla.Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse Response { get; set; }
        public IHttpClientFactory HttpClient { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            HttpClient = httpClientFactory;
            Response = new();
        }

        public async Task<T> SendApiRequestAsync<T>(APIRequest request)
        {
            try
            {
                var client = HttpClient.CreateClient("MagicVillaApi");

                HttpRequestMessage message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");

                message.RequestUri = new Uri(request.Uri);

                if (request.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");

                switch (request.ApiType)
                {
                    case ApiTypes.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiTypes.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiTypes.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;

                if (!string.IsNullOrWhiteSpace(request.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);
                }

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                try
                {
                    APIResponse APIResponseContent = JsonConvert.DeserializeObject<APIResponse>(apiContent);

                    if (apiResponse.StatusCode == HttpStatusCode.NotFound ||
                        apiResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        APIResponseContent.StatusCode = apiResponse.StatusCode;

                        APIResponseContent.IsSuccess = false;

                        var res = JsonConvert.SerializeObject(APIResponseContent);

                        var resObject = JsonConvert.DeserializeObject<T>(res);

                        return resObject;
                    }
                }
                catch (Exception e)
                {
                    var exceptionResponse = JsonConvert.DeserializeObject<T>(apiContent);

                    return exceptionResponse;
                }

                var apiResponseContent = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseContent;
            }
            catch (Exception e)
            {
                var errResponse = new APIResponse
                {
                    Errors = new List<string> { e.ToString() },
                    IsSuccess = false
                };

                var errRes = JsonConvert.SerializeObject(errResponse);

                var errApriResponse = JsonConvert.DeserializeObject<T>(errRes);

                return errApriResponse;
            }
        }
    }
}
