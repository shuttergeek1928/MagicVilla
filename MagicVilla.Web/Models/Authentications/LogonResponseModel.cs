namespace MagicVilla.Service.Models.Authentications
{
    public class LogonResponseModel
    {
        public Users? User { get; set; }
        public string? Token { get; set; }
    }
}