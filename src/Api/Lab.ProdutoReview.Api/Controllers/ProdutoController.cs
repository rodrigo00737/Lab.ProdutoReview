using AutoMapper;
using Lab.ProdutoReview.Api.Data.Repositories;
using Lab.ProdutoReview.Api.Entidades;
using Lab.ProdutoReview.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _repository.GetAll();

            var produtosViewModel = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return Ok(produtosViewModel);
        }

        //v1/api/getbyid/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _repository.GetById(id);

            if (produto is null)
            {
                return NotFound();
            }

            var produtoDetalhes = _mapper.Map<ProdutoDetalhesViewModel>(produto);

            return Ok(produtoDetalhes);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProdutoInputModel model)
        {
            var produto = new Produto(model.Titulo, model.Descricao, model.Preco);
            
            await _repository.Add(produto);
            
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, model);            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProdutoInputModel model)
        {
            if (model.Descricao.Length > 50)
            {
                return BadRequest();
            }

            var produto = await _repository.GetById(id);
            
            if (produto is null)
            {
                return NotFound();
            }

            await _repository.Update(produto);
            
            return NoContent();
        }
    }
}
