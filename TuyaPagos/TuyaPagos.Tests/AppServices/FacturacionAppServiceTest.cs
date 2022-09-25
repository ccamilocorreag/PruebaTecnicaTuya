using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Application.Services.Facturacion;
using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Services.Clientes;
using TuyaPagos.Domain.Services.Facturacion;
using TuyaPagos.Infraestructure.Exceptions;
using TuyaPagos.Infraestructure.Logging;

namespace TuyaPagos.Tests.AppServices
{
    public class FacturacionAppServiceTest
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogService<FacturacionAppService>> _logService;
        private readonly Mock<IClientesDomainService> _clientesDomainService;
        private readonly Mock<IFacturacionDomainService> _facturacionDomainService;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IFacturacionAppService _facturacionAppService;

        public FacturacionAppServiceTest()
        {
            _mapper = new Mock<IMapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _logService = new Mock<ILogService<FacturacionAppService>>();   
            _clientesDomainService = new Mock<IClientesDomainService>();    
            _facturacionDomainService = new Mock<IFacturacionDomainService>();
            _facturacionAppService = new FacturacionAppService(_unitOfWork.Object,
                _mapper.Object, _logService.Object, _clientesDomainService.Object,
                _facturacionDomainService.Object);
        }

        [Fact]
        public void WhenCreateFactura_ShouldBeSuccess()
        {
            //Arrange
            var facturaInput = new FacturaInputDto()
            {
                Cedula = "8102886",
                Nombres = "CRISTIAN CAMILO",
                Apellidos = "Correa Grajales",
                Observaciones = "Factura de prueba",
                DetalleFactura = new List<DetalleFacturaInputDto>()
                {
                    new DetalleFacturaInputDto() { Cantidad = 1, ProductoId = 1 },
                    new DetalleFacturaInputDto() { Cantidad = 1, ProductoId = 2 },
                    new DetalleFacturaInputDto() { Cantidad = 1, ProductoId = 3 },
                    new DetalleFacturaInputDto() { Cantidad = 1, ProductoId = 4 },
                }
            };
            var cliente = new Cliente()
            {
                Id = 1,
                Cedula = "8102886",
                Nombres = "CRISTIAN CAMILO",
                Apellidos = "Correa Grajales",
            };
            var factura = new Factura()
            {
                Observaciones = "Observaciones",
                DetalleFactura = new List<DetalleFactura>()
                {
                    new DetalleFactura() { Cantidad = 1, ProductoId = 1 },
                    new DetalleFactura() { Cantidad = 1, ProductoId = 2 },
                    new DetalleFactura() { Cantidad = 1, ProductoId = 3 },
                    new DetalleFactura() { Cantidad = 1, ProductoId = 4 }
                }
            };
            var detalleFacturaCalculada = factura.DetalleFactura;

            _mapper.Setup(s => s.Map<Cliente>(facturaInput)).Returns(cliente);
            _mapper.Setup(s => s.Map<Factura>(facturaInput)).Returns(factura);
            _clientesDomainService.Setup(s => s.CreateAndGetCliente(cliente)).ReturnsAsync(cliente);
            _facturacionDomainService.Setup(s => s.CalcularTotalesDetalleFactura(factura.DetalleFactura)).ReturnsAsync(detalleFacturaCalculada);
            _facturacionDomainService.Setup(s => s.CalcularTotales(factura)).Verifiable();
            _facturacionDomainService.Setup(s => s.GuardarFactura(factura)).Verifiable();
            
            //Act
            _facturacionAppService.CrearFactura(facturaInput);

            //Assert
            _facturacionDomainService.Verify(s => s.CalcularTotales(factura));
            _facturacionDomainService.Setup(s => s.GuardarFactura(factura));


        }

        [Fact]
        public async Task WhenGetFacturaById_ShouldBeFacturaAsync()
        {
            //Arrange
            var facturaId = 1;

            var factura = new Factura()
            {
                Id = 1,
                Fecha = DateTime.Now,
                Observaciones = "Observaciones",
                ValorBruto = 1000,
                Impuesto = 10,
                ValorNeto = 1010,
                ClienteId = 1
            };

            var facturaOutput = new FacturaOutputDto()
            {
                Id = 1,
                Fecha = DateTime.Now,
                Observaciones = "Observaciones",
                ValorBruto = 1000,
                Impuesto = 10,
                ValorNeto = 1010,
                ClienteId = 1
            };

            _mapper.Setup(s => s.Map<FacturaOutputDto>(factura)).Returns(facturaOutput);
            _facturacionDomainService.Setup(s => s.GetFacturaById(facturaId)).ReturnsAsync(factura);

            //Act
            var result = await _facturacionAppService.GetFacturaById(facturaId);

            //Assert
            Assert.Equal(result, facturaOutput);
            
        }

        [Fact]
        public void WhenGetFacturaById_ShouldBeNotFoundException()
        {
            //Arrange
            var facturaId = 1;
            
            //Act
            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => _facturacionAppService.GetFacturaById(facturaId));
        }

        [Fact]
        public async Task WhenGetFacturaCompletaById_ShouldBeFacturaAsync()
        {
            //Arrange
            var facturaId = 1;

            var factura = new Factura()
            {
                Id = 1,
                Fecha = DateTime.Now,
                Observaciones = "Observaciones",
                ValorBruto = 1000,
                Impuesto = 10,
                ValorNeto = 1010,
                ClienteId = 1,
                ClienteFk = new Cliente()
                {
                    Id = 1,
                    Cedula = "8102886",
                    Nombres = "CRISTIAN CAMILO",
                    Apellidos = "Correa Grajales",
                },
                DetalleFactura = new List<DetalleFactura>()
                {
                    new DetalleFactura()
                    {
                        Cantidad = 1,
                        ProductoId = 1,
                        ProductoFk = new Producto()
                        {
                            Nombre = "Tarjeta Crédito",
                            Precio = 1000,
                            PorcentajeImpuesto = 10
                        }
                    },
                    new DetalleFactura()
                    {
                        Cantidad = 1,
                        ProductoId = 2,
                        ProductoFk = new Producto()
                        {
                            Nombre = "Tarjeta Crédito 2",
                            Precio = 1000,
                            PorcentajeImpuesto = 10
                        }
                    }
                }
            };

            var facturaOutput = new FacturaOutputDto()
            {
                Id = 1,
                Fecha = DateTime.Now,
                Observaciones = "Observaciones",
                ValorBruto = 1000,
                Impuesto = 10,
                ValorNeto = 1010,
                ClienteId = 1,
                ClienteFk = new ClienteOutputDto()
                {
                    Id = 1,
                    Cedula = "8102886",
                    Nombres = "CRISTIAN CAMILO",
                    Apellidos = "Correa Grajales",
                },
                DetalleFactura = new List<DetalleFacturaOutputDto>()
                {
                    new DetalleFacturaOutputDto()
                    {
                        Cantidad = 1,
                        ProductoId = 1,
                        ProductoFk = new ProductoOutputDto()
                        {
                            Nombre = "Tarjeta Crédito",
                            Precio = 1000,
                            PorcentajeImpuesto = 10
                        }
                    },
                    new DetalleFacturaOutputDto()
                    {
                        Cantidad = 1,
                        ProductoId = 2,
                        ProductoFk = new ProductoOutputDto()
                        {
                            Nombre = "Tarjeta Crédito 2",
                            Precio = 1000,
                            PorcentajeImpuesto = 10
                        }
                    }
                }
            };

            _mapper.Setup(s => s.Map<FacturaOutputDto>(factura)).Returns(facturaOutput);
            _facturacionDomainService.Setup(s => s.GetFacturaCompletaById(facturaId)).ReturnsAsync(factura);

            //Act
            var result = await _facturacionAppService.GetFacturaCompletaById(facturaId);

            //Assert
            Assert.Equal(result, facturaOutput);


        }

        [Fact]
        public void WhenGetFacturaCompletaById_ShouldBeNotFoundException()
        {
            //Arrange
            var facturaId = 1;

            //Act
            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => _facturacionAppService.GetFacturaCompletaById(facturaId));
        }
    }
}
