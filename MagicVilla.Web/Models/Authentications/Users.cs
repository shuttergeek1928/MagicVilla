namespace MagicVilla.Service.Models.Authentications
{
    public class Users
    {
        public Guid Id { get; set; }
        public int AccountId { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
