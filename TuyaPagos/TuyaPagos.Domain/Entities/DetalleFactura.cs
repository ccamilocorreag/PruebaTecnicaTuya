namespace TuyaPagos.Domain.Entities
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public virtual Factura FacturaFk { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto ProductoFk { get; set; }
        public long ValorBruto { get; set; }
        public int Impuesto { get; set; }
        public long ValorNeto { get; set; }
    }
}
