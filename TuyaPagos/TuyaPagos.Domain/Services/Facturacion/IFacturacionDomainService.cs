using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Services.Facturacion
{
    public interface IFacturacionDomainService
    {
        Task GuardarFactura(Factura factura);
        Factura CalcularTotales(Factura factura);
        Task<Factura> GetFacturaById(int facturaId);
        Task<IEnumerable<DetalleFactura>> CalcularTotalesDetalleFactura(IEnumerable<DetalleFactura> detalleFactura);
    }
}
