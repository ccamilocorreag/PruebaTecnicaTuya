namespace TuyaPagos.Application.Dtos.Facturacion
{
    public class DetalleFacturaOutputDto
    {
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public virtual ProductoOutputDto Producto { get; set; }
        public long ValorBruto { get; set; }
        public int Impuesto { get; set; }
        public long ValorNeto { get; set; }
    }
}
