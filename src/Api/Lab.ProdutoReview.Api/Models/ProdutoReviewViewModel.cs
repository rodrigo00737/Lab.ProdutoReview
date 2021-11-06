using System;

namespace Lab.ProdutoReview.Api.Models
{
    public class ProdutoReviewViewModel
    {
        public ProdutoReviewViewModel(int id, string autor, int nota, string comentario, DateTime criadoEm)
        {
            Id = id;
            Autor = autor;
            Nota = nota;
            Comentario = comentario;
            CriadoEm = criadoEm;
        }

        public int Id { get; private set; }
        public string Autor { get; private set; }
        public int Nota { get; private set; }
        public string Comentario { get; private set; }
        public DateTime CriadoEm { get; private set; }
    }
}
