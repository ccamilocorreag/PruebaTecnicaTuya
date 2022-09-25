using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Interfaces
{
    public interface IFacturacionRepository: IGenericRepository<Factura>
    {
        Task<Factura> GetFacturaCompletaById(int id);
    }
}
