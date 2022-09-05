namespace MagicVilla.Web.SessionTokenStore
{
    public interface ISessionToken
    {
        public void SaveToken(string token);
        public string ReadToken();

    }
}

