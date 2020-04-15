using System.ComponentModel.DataAnnotations;

namespace Livraria.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}