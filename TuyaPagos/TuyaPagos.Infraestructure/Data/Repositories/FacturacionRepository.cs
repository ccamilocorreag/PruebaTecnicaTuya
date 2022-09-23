using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Infraestructure.Data.Repositories
{
    public class FacturacionRepository : GenericRepository<Factura>, IFacturacionRepository
    {
        public FacturacionRepository(TuyaPagosContext context) : base(context)
        {
        }


    }
}
