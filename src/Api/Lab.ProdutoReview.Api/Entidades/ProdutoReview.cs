using System;

namespace Lab.ProdutoReview.Api.Entidades
{
    public class ProdutoReview
    {
        public ProdutoReview(string autor, int nota, string comentario, int produtoId)
        {            
            Autor = autor;
            Nota = nota;
            Comentario = comentario;
            ProdutoId = produtoId;
            CriadoEm = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Autor { get; private set; }
        public int Nota { get; private set; }
        public string Comentario { get; private set; }
        public int ProdutoId { get; private set; }
        public DateTime CriadoEm { get; private set; }

        public Produto Produto { get; private set; }
    }
}
