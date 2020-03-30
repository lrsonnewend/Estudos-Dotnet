using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class StatusBook
    {
        [Key]
        public int StatusBookId { get; set; }

        [Required(ErrorMessage = "campo obrigatório.")]
        public int BookId { get; set; }
        
        [Required(ErrorMessage = "campo obrigatório.")]
        public int StatusId { get; set; }

        public Book Book { get; set; }

        public Status Status { get; set; }
    }
}