using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Services;
using TuyaPagos.Infraestructure.Logging;

namespace TuyaPagos.Application.Services.Facturacion
{
    public class FacturacionAppService : BaseService, IFacturacionAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService<FacturacionAppService> _logService;
        private readonly IClientesDomainService _clientesDomainService;
        private readonly IFacturacionDomainService _facturacionDomainService;
        private readonly IProductosDomainService _productosDomainService;

        public FacturacionAppService(IUnitOfWork unitOfWork, ILogService<FacturacionAppService> logService,
            IClientesDomainService clientesDomainService,
            IFacturacionDomainService facturacionDomainService,
            IProductosDomainService productosDomainService) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logService = logService;
            _clientesDomainService = clientesDomainService;
            _facturacionDomainService = facturacionDomainService;
            _productosDomainService = productosDomainService;
        }

        public async Task CrearFactura(FacturaInputDto facturaInput)
        {
            Cliente cliente = await CreateAndGetCliente(facturaInput);
            await CreateFactura(facturaInput, cliente);
            _unitOfWork.Complete();
            _logService.Log("Factura creada");
        }

        private async Task CreateFactura(FacturaInputDto facturaInput, Cliente cliente)
        {
            Factura factura = new()
            {
                ClienteId = cliente.Id,
                Cliente = cliente,
                Fecha = DateTime.Now,
                Observaciones = facturaInput.Observaciones,
                DetalleFactura = await MapearDetalle(facturaInput.DetalleFactura)
            };

            _facturacionDomainService.CalcularTotales(factura);

            await _facturacionDomainService.GuardarFactura(factura);
        }

        private async Task<List<DetalleFactura>> MapearDetalle(List<DetalleFacturaInputDto> listaDetalleFactura)
        {
            var detalleMapeado = new List<DetalleFactura>();
            foreach (var detalleFactura in listaDetalleFactura)
            {
                Producto producto = await _productosDomainService.GetProductoId(detalleFactura.ProductoId);

                detalleMapeado.Add(_facturacionDomainService.AgregarProductoFactura(new DetalleFactura()
                {
                    Cantidad = detalleFactura.Cantidad,
                    ProductoId = detalleFactura.ProductoId,
                    Producto = producto
                }));
            }

            return detalleMapeado;
        }

        private async Task<Cliente> CreateAndGetCliente(FacturaInputDto facturaInput)
        {
            Cliente newCliente = new()
            {
                Cedula = facturaInput.Cedula,
                Nombres = facturaInput.Nombres,
                Apellidos = facturaInput.Apellidos
            };

            await _clientesDomainService.CreateCliente(newCliente);
            _unitOfWork.Complete();

            return _clientesDomainService.GetClientByCedula(newCliente.Cedula);
        }
    }
}
