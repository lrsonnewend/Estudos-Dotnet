using System.ComponentModel.DataAnnotations;


namespace Livraria.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}