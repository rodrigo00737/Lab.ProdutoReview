using Lab.ProdutoReview.Api.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Data.Repositories
{
    public interface IProdutoRepository
    {
        Task Add(Produto produto);
        Task<List<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> GetDetalhesById(int id);
        Task Update(Produto produto);

        Task<Entidades.ProdutoReview> GetReviewById(int id);
        Task AddProdutoReview(Entidades.ProdutoReview produtoReview);


    }
}
