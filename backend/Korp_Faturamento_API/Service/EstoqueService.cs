using Korp.Faturamento.API.Entities;
using System.Text;
using System.Text.Json;

namespace Korp.Faturamento.API.Service
{
    public class EstoqueService : IEstoqueService
    {
        private readonly HttpClient _httpClient;
        public EstoqueService(HttpClient httpClient) { _httpClient = httpClient; }
        public async Task<bool> BaixarEstoqueAsync(IEnumerable<ItemNotaFiscal> itens)
        {
            if (itens == null || !itens.Any())
            {
                Console.WriteLine("Lista de itens está vazia");
                return false;
            }
            var payload = itens.Select(i => new
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade
            }).ToList();
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync("api/produtos/baixar-estoque", content);
                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro na API de Estoque ({response.StatusCode}): {erro}");
                }
                else
                {
                    Console.WriteLine("Estoque baixado com sucesso");
                }
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção ao chamar API de Estoque: {ex.Message}");
                return false;
            }
        }
    }
}