using AutoMapper;
using Lab.ProdutoReview.Api.Data;
using Lab.ProdutoReview.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lab.ProdutoReview.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoReviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProdutoController(ProdutoReviewDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _dbContext.Produtos;

            var produtosViewModel = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return Ok(produtosViewModel);
        }

        //v1/api/getbyid/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _dbContext.Produtos.SingleOrDefault(p => p.Id == id);
            if (produto is null)
            {
                return NotFound();
            }

            var produtoDetalhes = _mapper.Map<ProdutoDetalhesViewModel>(produto);

            return Ok(produtoDetalhes);
        }

        [HttpPost]
        public IActionResult Post(AddProdutoInputModel produtoInputModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, produtoInputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProdutoInputModel model)
        {
            if (model.Descricao.Length > 50)
            {
                return BadRequest();
            }

            var produto = _dbContext.Produtos.SingleOrDefault(p => p.Id == id);
            
            if (produto is null)
            {
                return NotFound();
            }

            produto.Update(model.Descricao, model.Preco);

            return NoContent();
        }


    }
}
