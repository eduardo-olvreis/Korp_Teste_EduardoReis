using System.ComponentModel.DataAnnotations;

namespace Korp.Faturamento.API.DTOs
{
    public class NotaFiscalCreateDto
    {
        [MinLength(1)]
        public List<ItemNotaFiscalCreateDto> Itens { get; set; } = new();
    }

    public class ItemNotaFiscalCreateDto
    {
        [Range(1, int.MaxValue)]
        public int ProdutoId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }
    }
}