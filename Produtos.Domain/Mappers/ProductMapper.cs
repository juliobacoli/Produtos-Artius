using Produtos.Application.Models;
using Produtos.Domain.Entities;

namespace Produtos.Application.Mappers;

public static class ProductMapper
{
    public static Product ToEntity(this CreateProductModel m)
        => new Product { Nome = m.Nome.Trim(), Preco = m.Preco, Categoria = m.Categoria.Trim() };

    public static ProductModel ToModel(this Product e)
        => new ProductModel { Id = e.Id, Nome = e.Nome, Preco = e.Preco, Categoria = e.Categoria };
}