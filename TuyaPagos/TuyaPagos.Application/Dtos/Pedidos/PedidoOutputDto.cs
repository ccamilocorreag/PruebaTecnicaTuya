namespace TuyaPagos.Application.Dtos.Pedidos
{
    public class PedidoOutputDto
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
    }
}
