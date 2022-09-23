namespace TuyaPagos.Application.Dtos.Facturacion
{
    public class FacturaInputDto
    {
        public string? Numero { get; set; }
        public string? Fecha { get; set; }
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Observaciones { get; set; }
        public DetalleFacturaInputDto? DetalleFactura { get; set; }
    }
}
