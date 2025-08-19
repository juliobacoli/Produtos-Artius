using Microsoft.Extensions.DependencyInjection;
using Produtos.Application.Services;
using Produtos.Domain.Interfaces;

namespace Produtos.Application.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}