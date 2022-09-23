using Microsoft.EntityFrameworkCore;
using TuyaPagos.Application.Services.Facturacion;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Infraestructure.Data;
using TuyaPagos.Infraestructure.Data.Repositories;

namespace TuyaPagos.WebApi.Extensions
{
    public static class ServiceCollectionExtension 
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(GenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IFacturacionRepository, FacturacionRepository>()
                .AddScoped<IClientesRepository, ClientesRepository>()
                .AddScoped<IProductosRepository, ProductosRepository>()
                .AddScoped<IPedidosRepository, PedidosRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<TuyaPagosContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("TuyaPagosContext")
                     ,b => b.MigrationsAssembly(typeof(TuyaPagosContext).Assembly.FullName)));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            return services
                .AddTransient<IFacturacionAppService, FacturacionAppService>();
        }
    }
}
