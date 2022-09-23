using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Domain.Services
{
    public class ClientesDomainService : IClientesDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientesDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCliente(Cliente newCliente)
        {
            var cliente = _unitOfWork.ClientesRepository.Find(x => x.Cedula == newCliente.Cedula).FirstOrDefault();
            if (cliente == null)
            {
                cliente = new()
                {
                    Cedula = newCliente.Cedula,
                    Nombres = newCliente.Nombres,
                    Apellidos = newCliente.Apellidos
                };

                await _unitOfWork.ClientesRepository.AddAsync(newCliente);

            }
        }

        public Cliente GetClientByCedula(string cedula)
        {
            return _unitOfWork.ClientesRepository.Find(x => x.Cedula == cedula).FirstOrDefault();
        }
    }
}
