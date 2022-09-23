using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Infraestructure.Data.Repositories
{
    public class ProductosRepository : GenericRepository<Producto>, IProductosRepository
    {
        public ProductosRepository(TuyaPagosContext context) : base(context)
        {
        }


    }
}
