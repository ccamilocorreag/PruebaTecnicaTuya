using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Services.Pedidos
{
    public interface IPedidosDomainService
    {
        Task CreatePedido(Pedido pedido);
        Task<Pedido> GetPedidoById(int id);
    }
}
