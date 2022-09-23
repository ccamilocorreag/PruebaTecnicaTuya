namespace TuyaPagos.Domain.Entities
{
    public class Factura
    {
        public Factura()
        {
            DetalleFactura = new List<DetalleFactura>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public long ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long ValorBruto { get; set; }
        public int Impuesto { get; set; }
        public long ValorNeto { get; set; }
        public virtual IEnumerable<DetalleFactura> DetalleFactura { get; set; }
    }
}
