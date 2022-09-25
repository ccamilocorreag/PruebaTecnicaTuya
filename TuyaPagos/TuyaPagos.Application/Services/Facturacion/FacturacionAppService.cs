using AutoMapper;
using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Services.Clientes;
using TuyaPagos.Domain.Services.Facturacion;
using TuyaPagos.Infraestructure.Exceptions;
using TuyaPagos.Infraestructure.Logging;

namespace TuyaPagos.Application.Services.Facturacion
{
    public class FacturacionAppService : BaseService, IFacturacionAppService
    {
        private readonly IMapper _mapper;
        private readonly ILogService<FacturacionAppService> _logService;
        private readonly IClientesDomainService _clientesDomainService;
        private readonly IFacturacionDomainService _facturacionDomainService;

        public FacturacionAppService(IUnitOfWork unitOfWork, IMapper mapper,
            ILogService<FacturacionAppService> logService,
            IClientesDomainService clientesDomainService,
            IFacturacionDomainService facturacionDomainService) : base(unitOfWork)
        {
            this._mapper = mapper;
            _logService = logService;
            _clientesDomainService = clientesDomainService;
            _facturacionDomainService = facturacionDomainService;
        }

        public async Task CrearFactura(FacturaInputDto facturaInput)
        {
            var cliente = _mapper.Map<Cliente>(facturaInput);
            var factura = _mapper.Map<Factura>(facturaInput);
            factura.ClienteFk = await _clientesDomainService.CreateAndGetCliente(cliente);
            factura.Fecha = DateTime.Now;
            factura.DetalleFactura = await _facturacionDomainService.CalcularTotalesDetalleFactura(factura.DetalleFactura);

            _facturacionDomainService.CalcularTotales(factura);

            await _facturacionDomainService.GuardarFactura(factura);

            UnitOfWork.Complete();
            _logService.Log("Factura creada");
        }

        public async Task<FacturaOutputDto> GetFacturaById(int id)
        {
            var factura = await _facturacionDomainService.GetFacturaById(id);
            if (factura is null) throw new NotFoundException("Factura no encontrada");

            return _mapper.Map<FacturaOutputDto>(factura);
        }
    }
}
