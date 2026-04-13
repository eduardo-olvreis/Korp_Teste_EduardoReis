using Korp.Faturamento.API.Data;
using Korp.Faturamento.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Korp.Faturamento.API.Repositories
{
    public class SqlNotaFiscalRepository : INotaFiscalRepository
    {
        private readonly AppDbContext _context;
        public SqlNotaFiscalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NotaFiscal?> ObterNotaPorIdAsync(int id)
        {
            return await _context.NotasFiscais.Include(n => n.Itens).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<NotaFiscal>> ObterTodasNotasAsync()
        {
            return await _context.NotasFiscais.AsNoTracking().Include(n => n.Itens).ToListAsync();
        }

        public async Task<NotaFiscal> CriarNotaFiscalAsync(NotaFiscal nota)
        {
            var temNota = await _context.NotasFiscais.AnyAsync();
            if (!temNota)
            {
                nota.NumeroSequencial = 1;
            }
            else
            {
                var maiorNumeroSequencial = await _context.NotasFiscais.MaxAsync(n => n.NumeroSequencial);
                nota.NumeroSequencial = maiorNumeroSequencial + 1;
            }
            nota.Status = "Aberta";
            await _context.AddAsync(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<bool> AtualizarStatusParaFechadaAsync(int id)
        {
            var nota = await ObterNotaPorIdAsync(id);
            if(nota == null) { return false; }
            nota.Status = "Fechada";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
