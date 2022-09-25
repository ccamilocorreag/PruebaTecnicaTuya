using AutoMapper;
using TuyaPagos.Application.Dtos.Pedidos;
using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Services.Facturacion;
using TuyaPagos.Domain.Services.Pedidos;
using TuyaPagos.Domain.Shared;
using TuyaPagos.Infraestructure.Exceptions;

namespace TuyaPagos.Application.Services.Pedidos
{
    public class PedidosAppService : BaseService, IPedidosAppService
    {
        private readonly IMapper _mapper;
        private readonly IPedidosDomainService _pedidosDomainService;
        private readonly IFacturacionDomainService _facturacionDomainService;

        public PedidosAppService(IUnitOfWork unitOfWork, IMapper mapper,
            IPedidosDomainService pedidosDomainService,
            IFacturacionDomainService facturacionDomainService) : base(unitOfWork)
        {
            _mapper = mapper;
            _pedidosDomainService = pedidosDomainService;
            _facturacionDomainService = facturacionDomainService;
        }

        public async Task CreatePedido(PedidoInputDto pedidoInput)
        {
            var factura = await _facturacionDomainService.GetFacturaById(pedidoInput.FacturaId);
            if (factura == null) throw new NotFoundException("La Factura no existe.");

            var pedido = _mapper.Map<Pedido>(pedidoInput);
            pedido.Estado = Enums.Estados.PREPARANDO.ToString();
            pedido.Fecha = DateTime.Now;

            await _pedidosDomainService.CreatePedido(pedido);

            UnitOfWork.Complete();
        }

        public async Task<PedidoOutputDto> GetPedidoById(int id)
        {
            var pedido = await _pedidosDomainService.GetPedidoById(id);
            if (pedido == null) throw new NotFoundException("Pedido no encontrado");

            return _mapper.Map<PedidoOutputDto>(pedido);
        }
    }
}
