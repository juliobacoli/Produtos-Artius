using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Produtos.Domain.Interfaces;
using Produtos.Infrastructure.Data;
using Produtos.Infrastructure.Repositories;

namespace Produtos.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("ProductsDb"));
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}