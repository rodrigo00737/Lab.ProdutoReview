using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Models
{
    public class UpdateProdutoInputModel
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
