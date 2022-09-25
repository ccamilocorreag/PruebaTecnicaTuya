using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Services.Productos;
using TuyaPagos.Domain.Shared;

namespace TuyaPagos.Domain.Services.Facturacion
{
    public class FacturacionDomainService : DomainServiceBase, IFacturacionDomainService
    {
        private readonly IProductosDomainService _productosDomainService;

        public FacturacionDomainService(IUnitOfWork unitOfWork,
            IProductosDomainService productosDomainService) : base(unitOfWork)
        {
            _productosDomainService = productosDomainService;
        }

        public Factura CalcularTotales(Factura factura)
        {
            factura.ValorBruto = factura.DetalleFactura.Sum(s => s.ValorBruto);
            factura.Impuesto = factura.DetalleFactura.Sum(s => s.Impuesto);
            factura.ValorNeto = factura.DetalleFactura.Sum(s => s.ValorNeto);
            return factura;
        }

        public Task<Factura> GetFacturaById(int facturaId)
        {
            return UnitOfWork.FacturacionRepository.GetByIdAsync(facturaId);
        }

        public async Task GuardarFactura(Factura factura)
        {
            await UnitOfWork.FacturacionRepository.AddAsync(factura);
        }

        public async Task<IEnumerable<DetalleFactura>> CalcularTotalesDetalleFactura(IEnumerable<DetalleFactura> detalleFactura)
        {
            foreach (var productoDetalleFactura in detalleFactura)
            {
                var producto = await _productosDomainService.GetProductoId(productoDetalleFactura.ProductoId);
                productoDetalleFactura.ProductoFk = producto;
                CalcularTotalProductoDetalleFactura(productoDetalleFactura);
            }

            return detalleFactura;
        }

        private static void CalcularTotalProductoDetalleFactura(DetalleFactura detalleFactura)
        {
            detalleFactura.ValorBruto = detalleFactura.ProductoFk.Precio * detalleFactura.Cantidad;
            detalleFactura.Impuesto = (int)(detalleFactura.ValorBruto * detalleFactura.ProductoFk.PorcentajeImpuesto / Constants.CIEN_PORCIENTO);
            detalleFactura.ValorNeto = detalleFactura.ValorBruto + detalleFactura.Impuesto;
        }
    }
}
