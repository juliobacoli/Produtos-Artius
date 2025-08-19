using Produtos.Application.DI;
using Produtos.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS liberado
builder.Services.AddCors(p => p.AddDefaultPolicy(
    b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
));

// DI
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Produtos API v1"));

app.UseCors();
app.MapControllers();

app.Run();