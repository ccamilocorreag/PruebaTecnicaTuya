using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Domain.Services.Clientes
{
    public class ClientesDomainService : DomainServiceBase, IClientesDomainService
    {

        public ClientesDomainService(IUnitOfWork unitOfWork): base(unitOfWork)
        {
        }

        public async Task<Cliente> CreateAndGetCliente(Cliente cliente)
        {
            var clienteExistente = UnitOfWork.ClientesRepository.Find(x => x.Cedula == cliente.Cedula).FirstOrDefault();
            if (clienteExistente == null)
            {
                await UnitOfWork.ClientesRepository.AddAsync(cliente);
                return cliente;
            }
            return clienteExistente;
        }
    }
}
