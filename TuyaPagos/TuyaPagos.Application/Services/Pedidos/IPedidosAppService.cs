using TuyaPagos.Application.Dtos.Pedidos;

namespace TuyaPagos.Application.Services.Pedidos
{
    public interface IPedidosAppService
    {
        Task CreatePedido(PedidoInputDto pedidoInput);
        Task<PedidoOutputDto> GetPedidoById(int id);
    }
}
