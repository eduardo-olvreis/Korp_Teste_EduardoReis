using Korp.Faturamento.API.DTOs;
using Korp.Faturamento.API.Entities;
using Korp.Faturamento.API.Repositories;
using Korp.Faturamento.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Korp.Faturamento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalRepository _repository;
        private readonly IEstoqueService _service;
        public NotaFiscalController(INotaFiscalRepository repository, IEstoqueService service)
        {
            _repository = repository;
            _service = service;
        }

        //Metodo para listar uma nota por ID
        [HttpGet("{id}", Name = "ObterNotaPorId")]
        public async Task<ActionResult<NotaFiscalResponseDto>> ObterNotaPorIdAsync(int id)
        {
            var nota = await _repository.ObterNotaPorIdAsync(id);
            if(nota == null) { return NotFound("Nenhuma nota registrada com esse ID."); }
            var response = new NotaFiscalResponseDto
            {
                Id = nota.Id,
                NumeroSequencial = nota.NumeroSequencial,
                Status = nota.Status,
                Itens = nota.Itens.Select(i => new ItemNotaFiscalResponseDto
                {
                    Id = i.Id,
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };
            return Ok(response);
        }

        //Metodo para listar todas as notas fiscais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaFiscalResponseDto>>> ObterTodasNotasAsync()
        {
            var notas = await _repository.ObterTodasNotasAsync();
            var response = notas.Select(n => new NotaFiscalResponseDto
            {
                Id = n.Id,
                NumeroSequencial = n.NumeroSequencial,
                Status = n.Status,
                Itens = n.Itens.Select(i => new ItemNotaFiscalResponseDto
                {
                    Id = i.Id,
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            });
            return Ok(response);
        }

        //Metodo para criar uma nota fiscal
        [HttpPost]
        public async Task<ActionResult<NotaFiscalResponseDto>> CriarNotaFiscalAsync(NotaFiscalCreateDto notaDto)
        {
            var nota = new NotaFiscal
            {
                Itens = notaDto.Itens.Select(i => new ItemNotaFiscal
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };
            await _repository.CriarNotaFiscalAsync(nota);
            var response = new NotaFiscalResponseDto
            {
                Id = nota.Id,
                NumeroSequencial = nota.NumeroSequencial,
                Status = nota.Status,
                Itens = nota.Itens.Select(i => new ItemNotaFiscalResponseDto
                {
                    Id = i.Id,
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };
            return CreatedAtRoute("ObterNotaPorId", new { id = response.Id }, response);
        }

        //Método para atualizar o status da nota para fechada
        [HttpPut("{id}/fechar")]
        public async Task<ActionResult> AtualizarStatusParaFechadaAsync(int id)
        {
            var nota = await _repository.ObterNotaPorIdAsync(id);
            if (nota == null) { return NotFound("Nenhuma nota registrada com esse ID."); }
            if (nota.Status == "Fechada") { return BadRequest("A nota já está com o status 'Fechada'."); }
            var sucessoEstoque = await _service.BaixarEstoqueAsync(nota.Itens);
            if (!sucessoEstoque) { return BadRequest("Falha ao baixar estoque. Verifique se há saldo disponível."); }
            await _repository.AtualizarStatusParaFechadaAsync(id);
            return Ok("Nota fiscal fechada e estoque atualizado.");
        }
    }
}
