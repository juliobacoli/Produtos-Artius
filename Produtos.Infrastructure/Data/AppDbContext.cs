using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;

namespace Produtos.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.NewGuid(), Nome = "Teclado Mecânico", Preco = 350, Categoria = "Periféricos" },
            new Product { Id = Guid.NewGuid(), Nome = "Mouse Gamer", Preco = 220, Categoria = "Periféricos" },
            new Product { Id = Guid.NewGuid(), Nome = "Monitor 27\" 144Hz", Preco = 1500, Categoria = "Monitores" },
            new Product { Id = Guid.NewGuid(), Nome = "Headset USB", Preco = 400, Categoria = "Áudio" },
            new Product { Id = Guid.NewGuid(), Nome = "Notebook Dell i7", Preco = 5200, Categoria = "Computadores" }
        );
    }
}