using Korp.Faturamento.API.Entities;

namespace Korp.Faturamento.API.DTOs
{
    public class NotaFiscalResponseDto
    {
        public int Id { get; set; }
        public int NumeroSequencial { get; set; }
        public string Status { get; set; }
        public List<ItemNotaFiscalResponseDto> Itens { get; set; } = new();
    }

    public class ItemNotaFiscalResponseDto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
