using Korp.Estoque.API.DTOs;
using Korp.Estoque.API.Entities;
using Korp.Estoque.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Korp.Estoque.API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        //Metodo para obter todos os produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponseDto>>> ObterProdutosAsync()
        {
            var produtos = await _repository.ObterProdutosAsync();
            var response = produtos.Select(p => new ProdutoResponseDto
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Descricao = p.Descricao,
                Saldo = p.Saldo,
            }).ToList();
            return Ok(response);
        }

        //Metodo para criar um produto
        [HttpPost]
        public async Task<ActionResult<ProdutoResponseDto>> CriarProdutoAsync(ProdutoCreateDto produtoDto)
        {
            var produto = new Produto
            {
                Codigo = produtoDto.Codigo,
                Descricao = produtoDto.Descricao,
                Saldo = produtoDto.Saldo,
            };
            await _repository.CriarProdutoAsync(produto);
            var response = new ProdutoResponseDto
            {
                Id = produto.Id,
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Saldo = produto.Saldo,
            };
            return Ok(response);
        }

        //Metodo para diminuir a quantidade de saldo em estoque
        [HttpPatch("{id}/debitar")]
        public async Task<ActionResult<ProdutoResponseDto>> DebitarEstoqueAsync(int id, [FromBody] int quantidade)
        {
            var produto = await _repository.DebitarEstoqueAsync(id, quantidade);
            if(produto == null) { return BadRequest("ID ou Saldo inválido"); }
            var response = new ProdutoResponseDto
            {
                Id = produto.Id,
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Saldo = produto.Saldo
            };
            return Ok(response);
        }

        //Método para processar a lista da nota fical
        [HttpPost("baixar-estoque")]
        public async Task<IActionResult> BaixarEstoqueEmLoteAsync([FromBody] List<ItemBaixaDto> itens)
        {
            if (itens == null || !itens.Any())
            {
                return BadRequest("A lista de itens está vazia.");
            }
            foreach (var item in itens)
            {
                var sucesso = await _repository.DebitarEstoqueAsync(item.ProdutoId, item.Quantidade);
                if (sucesso == null)
                {
                    return BadRequest($"Erro ao debitar produto ID {item.ProdutoId}. Verifique saldo ou existência.");
                }
            }
            return Ok();
        }
    }
}