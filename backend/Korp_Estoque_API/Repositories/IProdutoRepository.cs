using Korp.Estoque.API.Entities;

namespace Korp.Estoque.API.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterProdutosAsync();
        Task<Produto> CriarProdutoAsync(Produto produto);
        Task<Produto?> DebitarEstoqueAsync(int id, int quantidade);
    }
}
