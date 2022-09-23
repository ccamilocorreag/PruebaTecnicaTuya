using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Domain.Interfaces
{
    public interface IProductosRepository : IGenericRepository<Producto>
    {
    }
}
