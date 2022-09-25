namespace TuyaPagos.Application.Dtos.Facturacion
{
    public class FacturaOutputDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public ClienteOutputDto ClienteFk { get; set; }
        public long ValorBruto { get; set; }
        public int Impuesto { get; set; }
        public long ValorNeto { get; set; }
        public IEnumerable<DetalleFacturaOutputDto> DetalleFactura { get; set; }
        public string? Observaciones { get; set; }
    }
}
