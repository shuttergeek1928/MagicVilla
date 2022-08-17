using MagicVilla.Service.Models.Authentications;

namespace MagicVilla.Service.Authorization
{
    public interface IJwtTokenHandler
    {
        public AuthorizationClient GenerateToken(string secretKey, Users user);
    }
}
