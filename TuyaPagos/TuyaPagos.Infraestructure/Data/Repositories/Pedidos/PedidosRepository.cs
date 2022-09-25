using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Infraestructure.Data.Repositories.Pedidos
{
    public class PedidosRepository : GenericRepository<Pedido>, IPedidosRepository
    {
        public PedidosRepository(TuyaPagosContext context) : base(context)
        {
        }


    }
}
