using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Infraestructure.Data.Repositories.Clientes
{
    public class ClientesRepository : GenericRepository<Cliente>, IClientesRepository
    {
        public ClientesRepository(TuyaPagosContext context) : base(context)
        {
        }


    }
}
