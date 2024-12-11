using CRUDProduto.Infrastructure;
using Microsoft.OpenApi.Models;
using CRUDProduto.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Manage Products API",
        Description = "Documentação de API do sistema de cadastro de produtos"
    });

    s.EnableAnnotations();
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manage Products API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
