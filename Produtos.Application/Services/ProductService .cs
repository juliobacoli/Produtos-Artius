using Produtos.Application.Mappers;
using Produtos.Application.Models;
using Produtos.Domain.Interfaces;

namespace Produtos.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo) => _repo = repo;

    public async Task<ProductModel> CreateAsync(CreateProductModel model, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(model.Nome))
            throw new ArgumentException("Nome é obrigatório.", nameof(model.Nome));

        if (model.Preco <= 0)
            throw new ArgumentOutOfRangeException(nameof(model.Preco), "Preço deve ser maior que zero.");

        if (string.IsNullOrWhiteSpace(model.Categoria))
            throw new ArgumentException("Categoria é obrigatória.", nameof(model.Categoria));

        var entity = await _repo.AddAsync(model.ToEntity(), ct);
        return entity.ToModel();
    }

    public async Task<List<ProductModel>> ListAsync(CancellationToken ct = default)
    {
        var items = await _repo.ListAllAsync(ct);
        return items.Select(i => i.ToModel()).ToList();
    }
}