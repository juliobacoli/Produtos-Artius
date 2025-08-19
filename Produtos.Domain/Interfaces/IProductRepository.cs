using Produtos.Domain.Entities;

namespace Produtos.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> AddAsync(Product entity, CancellationToken ct = default);
    Task<List<Product>> ListAllAsync(CancellationToken ct = default);
}
