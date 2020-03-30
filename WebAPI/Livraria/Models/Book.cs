using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        
        [Required(ErrorMessage = "campo obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "campo obrigatório.")]
        public string Author { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        
    }
}