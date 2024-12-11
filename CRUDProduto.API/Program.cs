using CRUDProduto.Infrastructure;
using CRUDProduto.Application;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configura��o de infraestrutura com seus servi�os e reposit�rios
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
