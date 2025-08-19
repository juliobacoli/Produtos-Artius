namespace Produtos.Application.Models;

public class CreateProductModel
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public string Categoria { get; set; } = string.Empty;
}