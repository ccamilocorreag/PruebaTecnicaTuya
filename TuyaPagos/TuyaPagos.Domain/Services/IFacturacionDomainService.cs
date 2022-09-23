using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Services
{
    public interface IFacturacionDomainService
    {
        Task GuardarFactura(Factura factura);
        DetalleFactura AgregarProductoFactura(DetalleFactura detalleFactura);
        Factura CalcularTotales(Factura factura);
    }
}
