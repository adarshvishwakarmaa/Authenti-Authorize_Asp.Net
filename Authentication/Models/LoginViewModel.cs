using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
