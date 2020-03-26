using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models{
    
    public class Categoria{
        [Key]
        public int CategoriaId { get; set; }
    
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(3, ErrorMessage = "Campo válido a partir de 3 caracteres.")]
        public string Titulo { get; set; }

    }
}