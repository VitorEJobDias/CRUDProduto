using CRUDProduto.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using CRUDProduto.Application.Services;

namespace CRUDProduto.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddValidators();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            return services;
        }
    }
}
