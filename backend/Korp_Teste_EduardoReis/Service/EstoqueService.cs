using Korp.Faturamento.API.Entities;
using System.Text;
using System.Text.Json;

namespace Korp.Faturamento.API.Service
{
    public class EstoqueService : IEstoqueService
    {
        private readonly HttpClient _httpClient;
        public EstoqueService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> BaixarEstoqueAsync(IEnumerable<ItemNotaFiscal> itens)
        {
            var payload = itens.Select(i => new
            {
                produtoId = i.ProdutoId,
                quantidade = i.Quantidade
            });
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(payload, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync("api/produtos/baixar-estoque", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}