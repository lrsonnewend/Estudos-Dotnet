namespace projetoEntity.Models
{

    public class Produto
    {
        public Produto(string nome, string categoria, decimal preco)
        {
            this.nome = nome;
            this.categoria = categoria;
            this.preco = preco;
        }

        public int produtoId { get; set; }

        public string nome { get; set; }

        public string categoria { get; set; }

        public decimal preco { get; set; }
    }
}