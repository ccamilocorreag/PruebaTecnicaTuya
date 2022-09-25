using TuyaPagos.Application.Dtos.Facturacion;

namespace TuyaPagos.Application.Services.Facturacion
{
    public interface IFacturacionAppService
    {
        public Task CrearFactura(FacturaInputDto facturaInput);
        Task<FacturaOutputDto> GetFacturaById(int id);
    }
}
