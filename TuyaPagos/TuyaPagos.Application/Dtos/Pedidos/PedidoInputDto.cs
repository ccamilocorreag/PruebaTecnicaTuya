using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Application.Dtos.Pedidos
{
    public class PedidoInputDto
    {
        public int FacturaId { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
    }
}
