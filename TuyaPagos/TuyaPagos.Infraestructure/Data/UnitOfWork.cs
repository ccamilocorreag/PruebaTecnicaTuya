using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Infraestructure.Data.Repositories.Clientes;
using TuyaPagos.Infraestructure.Data.Repositories.Facturacion;
using TuyaPagos.Infraestructure.Data.Repositories.Pedidos;
using TuyaPagos.Infraestructure.Data.Repositories.Productos;

namespace TuyaPagos.Infraestructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TuyaPagosContext _context;
        public IFacturacionRepository FacturacionRepository { get; private set; }
        public IPedidosRepository PedidosRepository { get; private set; }
        public IClientesRepository ClientesRepository { get; private set; }
        public IProductosRepository ProductosRepository { get; private set; }

        public UnitOfWork(TuyaPagosContext context)
        {
            _context = context;
            FacturacionRepository = new FacturacionRepository(_context);
            PedidosRepository = new PedidosRepository(_context);
            ClientesRepository = new ClientesRepository(_context);
            ProductosRepository = new ProductosRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
