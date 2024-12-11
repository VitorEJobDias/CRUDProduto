using CRUDProduto.Core.Services;
using CRUDProduto.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CRUDProduto.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using CRUDProduto.Infrastructure.Persistence.Services;
using CRUDProduto.Infrastructure.Persistence.Repositories;

namespace CRUDProduto.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProductDb");

            services
                .AddDb(connectionString)
                .AddRepositories()
                .AddServices();

            return services;
        }

        private static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<CRUDProdutoContext>(options =>
              options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CRUDProduto.Infrastructure")));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddAutoMapper(typeof(MappingService));

            return services;
        }
    }
}
