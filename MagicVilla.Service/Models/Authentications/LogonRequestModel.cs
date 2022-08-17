using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.Authentications
{
    public class LogonRequestModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
