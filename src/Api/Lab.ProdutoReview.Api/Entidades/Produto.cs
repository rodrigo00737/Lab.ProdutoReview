using System;
using System.Collections.Generic;

namespace Lab.ProdutoReview.Api.Entidades
{
    public class Produto
    {
        public Produto(int id, string titulo, string descricao, decimal preco)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            CriadoEm = DateTime.Now;
            Avaliacoes = new List<ProdutoReview>();
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime CriadoEm { get; private set; }
         
        public List<ProdutoReview> Avaliacoes { get; private set; }

        public void AddReview( ProdutoReview produtoReview)
        {
            Avaliacoes.Add(produtoReview);
        }

        public void Update(string descricao, decimal preco)
        {
            Descricao = descricao;
            Preco = preco;
        }
    }
}
