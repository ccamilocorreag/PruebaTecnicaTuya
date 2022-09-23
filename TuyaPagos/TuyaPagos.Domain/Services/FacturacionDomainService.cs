using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Shared;

namespace TuyaPagos.Domain.Services
{
    public class FacturacionDomainService : IFacturacionDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacturacionDomainService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public DetalleFactura AgregarProductoFactura(DetalleFactura detalleFactura)
        {
            detalleFactura.ValorBruto = detalleFactura.Producto.Precio * detalleFactura.Cantidad;
            detalleFactura.Impuesto = (int)(detalleFactura.ValorBruto * detalleFactura.Producto.PorcentajeImpuesto / Constants.CIEN_PORCIENTO);
            detalleFactura.ValorNeto = detalleFactura.ValorBruto + detalleFactura.Impuesto;
            return detalleFactura;
        }

        public Factura CalcularTotales(Factura factura)
        {
            factura.ValorBruto = factura.DetalleFactura.Sum(s => s.ValorBruto);
            factura.Impuesto = factura.DetalleFactura.Sum(s => s.Impuesto);
            factura.ValorNeto = factura.DetalleFactura.Sum(s => s.ValorNeto);
            return factura;
        }

        public async Task GuardarFactura(Factura factura)
        {
            await _unitOfWork.FacturacionRepository.AddAsync(factura);
        }
    }
}
