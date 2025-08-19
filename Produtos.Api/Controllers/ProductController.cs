using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Models;
using Produtos.Domain.Interfaces;

namespace Produtos.Api.Controllers;

[ApiController]
[Route("produto")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service) => _service = service;

    [HttpPost]
    public async Task<ActionResult<ProductModel>> Create([FromBody] CreateProductModel model, CancellationToken ct)
    {
        var result = await _service.CreateAsync(model, ct);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductModel>>> List(CancellationToken ct)
    {
        var result = await _service.ListAsync(ct);
        return Ok(result);
    }
}