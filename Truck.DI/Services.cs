using Microsoft.Extensions.DependencyInjection;
using Truck.Data;
using Truck.Data.Repositories;
using Truck.Domain.Repositories;

namespace Truck.DI
{
    public static class Services
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<TruckContext>();

            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        }
    }
}
