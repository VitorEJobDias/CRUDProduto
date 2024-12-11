using CRUDProduto.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configuração de infraestrutura com seus serviços e repositórios
builder.Services
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
