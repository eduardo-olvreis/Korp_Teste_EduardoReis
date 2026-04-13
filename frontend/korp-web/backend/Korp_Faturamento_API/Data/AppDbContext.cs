using Korp.Faturamento.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Korp.Faturamento.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<ItemNotaFiscal> ItensNotaFiscal { get; set; }
    }
}
