using Microsoft.EntityFrameworkCore;
using TuyaPagos.Application.Services.Facturacion;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Services;
using TuyaPagos.Infraestructure.Data;
using TuyaPagos.Infraestructure.Data.Repositories;
using TuyaPagos.Infraestructure.Logging;

namespace TuyaPagos.WebApi.Extensions
{
    public static class ServiceCollectionExtension 
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IFacturacionRepository, FacturacionRepository>()
                .AddScoped<IClientesRepository, ClientesRepository>()
                .AddScoped<IProductosRepository, ProductosRepository>()
                .AddScoped<IPedidosRepository, PedidosRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(ILogService<>), typeof(LogService<>))
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
                .AddScoped<IClientesDomainService, ClientesDomainService>()
                .AddScoped<IFacturacionDomainService, FacturacionDomainService>()
                .AddScoped<IProductosDomainService, ProductosDomainService>()

                .AddScoped<IFacturacionAppService, FacturacionAppService>();
        }
    }
}
