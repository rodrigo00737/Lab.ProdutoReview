using Lab.ProdutoReview.Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Data
{
    public class ProdutoReviewDbContext
    {
        public ProdutoReviewDbContext()
        {
            Produtos = new List<Produto>();
        }

        public List<Produto> Produtos { get; set; }
    }
}
