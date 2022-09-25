using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Domain.Services.Pedidos
{
    public class PedidosDomainService : DomainServiceBase, IPedidosDomainService
    {
        public PedidosDomainService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task CreatePedido(Pedido pedido)
        {
            await UnitOfWork.PedidosRepository.AddAsync(pedido);
        }

        public async Task<Pedido> GetPedidoById(int id)
        {
            return await UnitOfWork.PedidosRepository.GetByIdAsync(id);
        }

        public async Task<Pedido> GetFacturasByPedidoId(int id)
        {
            var pedido = await UnitOfWork.PedidosRepository.GetByIdAsync(id);
            return pedido;
        }
    }
}
