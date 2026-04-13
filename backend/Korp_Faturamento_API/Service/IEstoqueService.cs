using Korp.Faturamento.API.Entities;

namespace Korp.Faturamento.API.Service
{
    public interface IEstoqueService
    {
        Task<bool> BaixarEstoqueAsync(IEnumerable<ItemNotaFiscal> itens);
    }
}
