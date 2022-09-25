using Microsoft.EntityFrameworkCore;
using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Infraestructure.Data.Repositories.Facturacion
{
    public class FacturacionRepository : GenericRepository<Factura>, IFacturacionRepository
    {
        public FacturacionRepository(TuyaPagosContext context) : base(context)
        {
        }

        public async Task<Factura> GetFacturaCompletaById(int id)
        {
            return await _context.Facturas
                .Include(x => x.ClienteFk)
                .Include(x => x.DetalleFactura).ThenInclude(x => x.ProductoFk)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
