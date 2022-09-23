namespace TuyaPagos.Application.Dtos.Facturacion
{
    public class FacturaInputDto
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string? Observaciones { get; set; }
        public List<DetalleFacturaInputDto> DetalleFactura { get; set; }
    }
}
