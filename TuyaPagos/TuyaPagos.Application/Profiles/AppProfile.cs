using AutoMapper;
using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Application.Dtos.Pedidos;
using TuyaPagos.Domain.Entities;

namespace TuyaPagos.Application.Profiles
{
    public class AppProfile: Profile
    {
        public AppProfile()
        {
            CreateMap<FacturaOutputDto, Factura>().ReverseMap();
            CreateMap<FacturaInputDto, Factura>().ReverseMap();
            CreateMap<DetalleFacturaOutputDto, DetalleFactura>().ReverseMap();
            CreateMap<DetalleFacturaInputDto, DetalleFactura>().ReverseMap();

            CreateMap<ClienteOutputDto, Cliente>().ReverseMap();    
            CreateMap<FacturaInputDto, Cliente>();

            CreateMap<ProductoOutputDto, Producto>().ReverseMap();

            CreateMap<PedidoOutputDto, Pedido>().ReverseMap();
            CreateMap<PedidoInputDto, Pedido>().ReverseMap();
        }
    }
}
