namespace TuyaPagos.Domain.Entities
{
    public class Producto
    {
        public Producto()
        {
            DetalleFactura = new List<DetalleFactura>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Precio { get; set; }
        public int PorcentajeImpuesto { get; set; }
        public virtual IEnumerable<DetalleFactura> DetalleFactura { get; set; }

    }
}
