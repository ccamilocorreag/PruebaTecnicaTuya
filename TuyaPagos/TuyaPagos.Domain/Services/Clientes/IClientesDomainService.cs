using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Services.Clientes
{
    public interface IClientesDomainService
    {
        Task<Cliente> CreateAndGetCliente(Cliente cliente);
    }
}
