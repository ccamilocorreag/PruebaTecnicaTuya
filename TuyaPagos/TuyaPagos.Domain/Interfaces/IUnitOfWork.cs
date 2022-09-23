namespace TuyaPagos.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFacturacionRepository FacturacionRepository { get; }
        IPedidosRepository PedidosRepository { get; }
        IClientesRepository ClientesRepository { get; }
        IProductosRepository ProductosRepository { get; }
        int Complete();
    }
}
