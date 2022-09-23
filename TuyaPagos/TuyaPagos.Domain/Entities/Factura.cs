namespace TuyaPagos.Domain.Entities
{
    public class Factura
    {
        public Factura()
        {
            DetalleFactura = new List<DetalleFactura>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long ValorBruto { get; set; }
        public int Impuesto { get; set; }
        public long ValorNeto { get; set; }
        public virtual IEnumerable<DetalleFactura> DetalleFactura { get; set; }
        public string? Observaciones { get; set; }
    }
}
