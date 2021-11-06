using Lab.ProdutoReview.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.ProdutoReview.Api.Controllers
{
    [ApiController]
    [Route("v1/api/{produtoId}/produtoReviews")]
    public class ProdutoReviewController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int produtoId, int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int produtoId, AddProdutoReviewInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1, produtoId = 2}, model);
        }
    }
}
