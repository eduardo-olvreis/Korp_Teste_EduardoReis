using Korp.Estoque.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Korp.Estoque.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
