
using Produtos.Application.Models;

namespace Produtos.Domain.Interfaces;

public interface IProductService
{
    Task<ProductModel> CreateAsync(CreateProductModel model, CancellationToken ct = default);
    Task<List<ProductModel>> ListAsync(CancellationToken ct = default);
}