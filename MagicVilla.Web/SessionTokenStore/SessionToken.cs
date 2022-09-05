using MagicVilla.Utility;

namespace MagicVilla.Web.SessionTokenStore
{
    public class SessionToken : ISessionToken
    {
        private IHttpContextAccessor HttpContextAccessor;

        public SessionToken(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public void SaveToken(string token)
        {
            HttpContextAccessor.HttpContext.Session.SetString(SessionTokenConstant.SessionTokenKey, token);
        }

        public string ReadToken()
        {
            return HttpContextAccessor.HttpContext.Session.GetString(SessionTokenConstant.SessionTokenKey);
        }
    }
}

