using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Produto
    {
        
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(3, ErrorMessage = "Campo válido a partir de 3 caracteres.")]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }


        
    }
}