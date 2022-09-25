using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Services.Productos
{
    public interface IProductosDomainService
    {
        Task<Producto> GetProductoId(int productoId);
    }
}
