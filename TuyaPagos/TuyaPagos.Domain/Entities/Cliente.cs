namespace TuyaPagos.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Facturas = new List<Factura>();
        }
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public virtual IEnumerable<Factura> Facturas { get; set; }

    }
}
