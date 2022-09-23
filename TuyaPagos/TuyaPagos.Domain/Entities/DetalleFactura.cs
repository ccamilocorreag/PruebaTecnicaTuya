namespace TuyaPagos.Domain.Entities
{
    public class DetalleFactura
    {
        public long Id { get; set; }
        public long FacturaId { get; set; }
        public virtual Factura Factura { get; set; }
        public int Cantidad { get; set; }
        public long ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public long ValorBruto { get; set; }
        public int Impuesto { get; set; }
        public long ValorNeto { get; set; }
    }
}
