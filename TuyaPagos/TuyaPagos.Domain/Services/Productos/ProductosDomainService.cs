using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Domain.Services.Productos
{
    public class ProductosDomainService : DomainServiceBase, IProductosDomainService
    {

        public ProductosDomainService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Producto> GetProductoId(int productoId)
        {
            return await UnitOfWork.ProductosRepository.GetByIdAsync(productoId);
        }
    }
}
