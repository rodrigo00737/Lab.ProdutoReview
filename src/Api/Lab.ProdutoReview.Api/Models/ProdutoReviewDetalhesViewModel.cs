using System;

namespace Lab.ProdutoReview.Api.Models
{
    public class ProdutoReviewDetalhesViewModel
    {
        public int Id { get; private set; }
        public string Autor { get; private set; }
        public int Nota { get; private set; }
        public string Comentario { get; private set; }
        public int ProdutoId { get; private set; }
        public DateTime CriadoEm { get; private set; }

    }
}
