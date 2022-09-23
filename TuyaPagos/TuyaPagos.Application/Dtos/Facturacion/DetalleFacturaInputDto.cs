namespace TuyaPagos.Application.Dtos.Facturacion
{
    public class DetalleFacturaInputDto
    {
        public long Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
