using AutoMapper;
using Lab.ProdutoReview.Api.Data.Repositories;
using Lab.ProdutoReview.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Controllers
{
    [ApiController]
    [Route("v1/api/{produtoId}/produtoReviews")]
    public class ProdutoReviewController : ControllerBase
    {
        private readonly ProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoReviewController(ProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }      

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int produtoId, int id)
        {
            var produtoReview = await _repository.GetReviewById(id);

            if (produtoReview is null)
            {
                return NotFound();
            }

            var produtoDetalhes = _mapper.Map<ProdutoReviewDetalhesViewModel>(produtoReview);
            produtoDetalhes.CriadoEm.ToString("s");

            return Ok(produtoDetalhes);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int produtoId, AddProdutoReviewInputModel model)
        {
            var produtoReview = new Entidades.ProdutoReview(model.Autor, model.Nota, model.Comentario, produtoId);

            await _repository.AddProdutoReview(produtoReview);            

            return CreatedAtAction(nameof(GetById), new { id = produtoReview.Id, produtoId = produtoId}, model);
        }
    }
}
