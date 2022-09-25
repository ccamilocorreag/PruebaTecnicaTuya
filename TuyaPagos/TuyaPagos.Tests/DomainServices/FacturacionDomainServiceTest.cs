using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuyaPagos.Domain.Entities;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Domain.Services.Facturacion;
using TuyaPagos.Domain.Services.Productos;

namespace TuyaPagos.Tests.DomainServices
{

    public class FacturacionDomainServiceTest
    {
        private readonly Mock<IProductosDomainService> _productosDomainService;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IFacturacionDomainService _facturacionDomainservice;
        public FacturacionDomainServiceTest()
        {
            _productosDomainService = new Mock<IProductosDomainService>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _facturacionDomainservice = new FacturacionDomainService(_unitOfWork.Object, _productosDomainService.Object);
        }

        [Fact]
        public void WhenCalcularTotales_ShouldBeSuccess()
        {
            //Arrange
            var factura = new Factura()
            {
                DetalleFactura = new List<DetalleFactura>()
                {
                    new DetalleFactura()
                    {
                        Cantidad = 1,
                        ValorBruto = 100,
                        Impuesto = 10,
                        ValorNeto = 110
                    },
                    new DetalleFactura()
                    {
                        Cantidad = 1,
                        ValorBruto = 100,
                        Impuesto = 10,
                        ValorNeto = 110
                    }
                }
            };

            //act
            var result = _facturacionDomainservice.CalcularTotales(factura);

            //Assert
            Assert.Equal(200, result.ValorBruto);
            Assert.Equal(20, result.Impuesto);
            Assert.Equal(220, result.ValorNeto);

        }

        [Fact]
        public async Task WhenGetFacturaById_ShouldBeSuccess()
        {
            //Arrange
            var facturaId = 1;
            var factura = new Factura()
            {
                Id = facturaId,
                ClienteId = 1,
                Fecha = DateTime.Now,
                ValorBruto = 1000,
                Impuesto = 100,
                ValorNeto = 1100,
                Observaciones = "Factura de prueba"
            };

            _unitOfWork.Setup(s => s.FacturacionRepository.GetByIdAsync(facturaId)).ReturnsAsync(factura);

            //act
            var result = await _facturacionDomainservice.GetFacturaById(facturaId);

            //Assert
            Assert.Equal(factura, result);
        }

        [Fact]
        public async Task WhenGetFacturaCompletaById_ShouldBeSuccess()
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

            _unitOfWork.Setup(s => s.FacturacionRepository.GetFacturaCompletaById(facturaId)).ReturnsAsync(factura);

            //act
            var result = await _facturacionDomainservice.GetFacturaCompletaById(facturaId);

            //Assert
            Assert.Equal(factura, result);
        }

        [Fact]
        public async Task WhenGuardarFactura_ShouldBeSuccess()
        {
            //Arrange
            var factura = new Factura()
            {
                ClienteId = 1,
                Fecha = DateTime.Now,
                ValorBruto = 1000,
                Impuesto = 100,
                ValorNeto = 1100,
                Observaciones = "Factura de prueba"
            };

            _unitOfWork.Setup(s => s.FacturacionRepository.AddAsync(factura)).Verifiable();

            //act
            await _facturacionDomainservice.GuardarFactura(factura);

            //Assert
            _unitOfWork.Verify(s => s.FacturacionRepository.AddAsync(factura));
        }

        [Fact]
        public async Task WhenCalcularTotalesDetalleFactura_ShouldBeSuccessAsync()
        {
            //Arrange
            var factura = new Factura()
            {
                DetalleFactura = new List<DetalleFactura>()
                {
                    new DetalleFactura()
                    {
                        Cantidad = 1,
                        ProductoId = 1
                    },
                    new DetalleFactura()
                    {
                        Cantidad = 1,
                        ProductoId = 2
                    }
                }
            };
            var producto1 = new Producto()
            {
                Id = 1,
                Nombre = "Tarjeta 1",
                Descripcion = "Tarjeta 1",
                PorcentajeImpuesto = 10,
                Precio = 1000
            };

            var producto2 = new Producto()
            {
                Id = 1,
                Nombre = "Tarjeta 1",
                Descripcion = "Tarjeta 1",
                PorcentajeImpuesto = 10,
                Precio = 1000
            };

            _productosDomainService.Setup(s => s.GetProductoId(It.IsAny<int>())).ReturnsAsync(producto1);
            _productosDomainService.Setup(s => s.GetProductoId(It.IsAny<int>())).ReturnsAsync(producto2);

            //act
            var result = await _facturacionDomainservice.CalcularTotalesDetalleFactura(factura.DetalleFactura);

            //Assert
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(1000, item.ValorBruto);
                    Assert.Equal(100, item.Impuesto);
                    Assert.Equal(1100, item.ValorNeto);
                },
                item =>
                {
                    Assert.Equal(1000, item.ValorBruto);
                    Assert.Equal(100, item.Impuesto);
                    Assert.Equal(1100, item.ValorNeto);
                }
                );
        }
    }
}
