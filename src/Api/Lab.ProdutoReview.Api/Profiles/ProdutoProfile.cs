using AutoMapper;
using Lab.ProdutoReview.Api.Entidades;
using Lab.ProdutoReview.Api.Models;

namespace Lab.ProdutoReview.Api.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Entidades.ProdutoReview, ProdutoReviewViewModel>();
            CreateMap<Entidades.ProdutoReview, ProdutoReviewDetalhesViewModel>();

            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Produto, ProdutoDetalhesViewModel>();
        }
    }
}
