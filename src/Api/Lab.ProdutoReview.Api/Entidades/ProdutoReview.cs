using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Entidades
{
    public class ProdutoReview
    {
        public ProdutoReview(int id, string autor, int nota, string comentario, int produtoId)
        {
            Id = id;
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
    }
}
