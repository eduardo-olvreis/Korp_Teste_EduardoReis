using Korp.Faturamento.API.Entities;

namespace Korp.Faturamento.API.Repositories
{
    public interface INotaFiscalRepository
    {
        public Task<NotaFiscal> ObterNotaPorIdAsync(int id);
        public Task<IEnumerable<NotaFiscal>> ObterTodasNotasAsync();
        public Task<NotaFiscal> CriarNotaFiscal(NotaFiscal nota);
        public Task<bool> AtualizarStatusParaFechadaAsync(int id);
    }
}
