using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Domain.Services
{
    public class ProductosDomainService : IProductosDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductosDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Producto> GetProductoId(int productoId)
        {
            return await _unitOfWork.ProductosRepository.GetByIdAsync(productoId);
        }
    }
}
