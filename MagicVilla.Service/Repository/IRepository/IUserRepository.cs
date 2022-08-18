using MagicVilla.Service.Models.Authentications;
using MagicVilla.Service.Models.Registration;
namespace MagicVilla.Service.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(int accountId);
        LogonResponseModel Logon(LogonRequestModel logonRequestModel);
        Users? Register(RegistrationRequestModel registrationRequestModel);
    }
}
