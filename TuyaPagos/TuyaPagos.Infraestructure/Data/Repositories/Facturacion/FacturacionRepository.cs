using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Infraestructure.Data.Repositories.Facturacion
{
    public class FacturacionRepository : GenericRepository<Factura>, IFacturacionRepository
    {
        public FacturacionRepository(TuyaPagosContext context) : base(context)
        {
        }


    }
}
