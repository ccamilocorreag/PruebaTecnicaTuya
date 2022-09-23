using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Services
{
    public interface IClientesDomainService
    {
        Task CreateCliente(Cliente newCliente);
        Cliente GetClientByCedula(string cedula);
    }
}
