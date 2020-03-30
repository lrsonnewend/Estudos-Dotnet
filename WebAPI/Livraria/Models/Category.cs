using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "campo obrigatório.")]
        public string Name { get; set; }
    }
}