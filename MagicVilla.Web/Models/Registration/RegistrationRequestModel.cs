using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Service.Models.Registration
{
    public class RegistrationRequestModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}
