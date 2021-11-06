namespace Lab.ProdutoReview.Api.Models
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(int id, string titulo, decimal preco)
        {
            Id = id;
            Titulo = titulo;
            Preco = preco;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public decimal Preco { get; private set; }
    }
}
