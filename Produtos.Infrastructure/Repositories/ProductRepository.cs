using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces;
using Produtos.Infrastructure.Data;

namespace Produtos.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _ctx;
    public ProductRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<Product> AddAsync(Product entity, CancellationToken ct = default)
    {
        await _ctx.Products.AddAsync(entity, ct);
        await _ctx.SaveChangesAsync(ct);
        return entity;
    }

    public Task<List<Product>> ListAllAsync(CancellationToken ct = default) =>
        _ctx.Products.AsNoTracking().ToListAsync(ct);
}