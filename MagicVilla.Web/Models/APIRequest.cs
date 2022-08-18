using static MagicVilla.Utility.ApiTypes;

namespace MagicVilla.Web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Uri { get; set; }
        public object Data { get; set; }

    }
}
