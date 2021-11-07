using Lab.ProdutoReview.Api.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoReviewDbContext _dbContext;

        public ProdutoRepository(ProdutoReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Produto produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddProdutoReview(Entidades.ProdutoReview produtoReview)
        {
            await _dbContext.ProdutoReviews.AddAsync(produtoReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _dbContext
                            .Produtos                            
                            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Produto> GetDetalhesById(int id)
        {
            return await _dbContext
                            .Produtos
                            .Include(p=> p.Avaliacoes)
                            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Entidades.ProdutoReview> GetReviewById(int id)
        {
            return await _dbContext
                            .ProdutoReviews
                            .Include(p => p.Produto)
                            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Produto produto)
        {
            _dbContext.Produtos.Update(produto);
            await _dbContext.SaveChangesAsync();
        }
    }
}
