namespace TuyaPagos.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public int FacturaId { get; set; }
        public virtual Factura Factura { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Estado { get; set; }
    }
}
