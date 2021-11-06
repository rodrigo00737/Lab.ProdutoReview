using System;
using System.Collections.Generic;

namespace Lab.ProdutoReview.Api.Models
{
    public class ProdutoDetalhesViewModel
    {
        public ProdutoDetalhesViewModel(int id, string titulo, string descricao, decimal preco, DateTime criadoEm)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            CriadoEm = criadoEm;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime CriadoEm { get; private set; }

        public List<ProdutoReviewViewModel> Avaliacoes { get; private set; }
    }
}
