using Korp.Estoque.API.Data;
using Korp.Estoque.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Korp.Estoque.API.Repositories
{
    public class SqlProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public SqlProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> CriarProdutoAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto?> DebitarEstoqueAsync(int id, int quantidade)
        {
            Produto produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if(produto == null) { return null; }
            if(produto.Saldo < quantidade) { return null; }
            produto.Saldo = produto.Saldo - quantidade;
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}
