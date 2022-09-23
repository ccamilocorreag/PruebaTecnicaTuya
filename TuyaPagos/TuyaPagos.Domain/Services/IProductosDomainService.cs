using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Services
{
    public interface IProductosDomainService
    {
        Task<Producto> GetProductoId(int productoId);
    }
}
