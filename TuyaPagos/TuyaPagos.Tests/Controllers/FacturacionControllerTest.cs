using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Application.Services.Facturacion;
using TuyaPagos.Infraestructure.Logging;
using TuyaPagos.WebApi.Controllers;

namespace TuyaPagos.Tests.Controllers
{
    public class FacturacionControllerTest
    {
        private readonly Mock<IFacturacionAppService> _facturacionAppService;
        private readonly Mock<ILogService<FacturacionController>> _logService;
        private readonly FacturacionController _facturacionController;

        public FacturacionControllerTest()
        {
            _facturacionAppService = new Mock<IFacturacionAppService>();
            _logService = new Mock<ILogService<FacturacionController>>();
            _facturacionController = new FacturacionController(_facturacionAppService.Object, _logService.Object);
        }

        [Fact]
        public async Task WhenCreateFactura_ShouldNoContentResult()
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

            _facturacionAppService.Setup(s => s.CrearFactura(facturaInput)).Verifiable();
            _logService.Setup(s => s.Log(It.IsAny<string>())).Verifiable();

            //Act
            var result = await _facturacionController.Create(facturaInput);
            var noContentResult = result as NoContentResult;

            //Assert
            _facturacionAppService.Verify(s => s.CrearFactura(facturaInput));
            _logService.Verify(s => s.Log(It.IsAny<string>()));

            Assert.Equal(204, noContentResult.StatusCode);

        }

        [Fact]
        public async Task WhenGetFacturaCompletaByIdFactura_ShouldReturnFactura()
        {
            //Arrange 
            var idFactura = 1;
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
            _facturacionAppService.Setup(s => s.GetFacturaCompletaById(idFactura)).ReturnsAsync(facturaOutput);
            _logService.Setup(s => s.Log(It.IsAny<string>())).Verifiable();

            //Act
            var result = await _facturacionController.GetFacturaCompletaById(idFactura);
            var okResul = result as OkObjectResult;
            var output = okResul.Value as FacturaOutputDto;

            //Assert
            _logService.Verify(s => s.Log(It.IsAny<string>()));

            Assert.NotNull(okResul);
            Assert.NotNull(output);
            Assert.Equal(facturaOutput, output);
        }

        [Fact]
        public async Task WhenGetByIdFactura_ShouldReturnFactura()
        {
            //Arrange 
            var idFactura = 1;
            var facturaOutput = new FacturaOutputDto()
            {
                Id = 1,
                Fecha = DateTime.Now,
                Observaciones = "Observaciones",
                ValorBruto = 1000,
                Impuesto = 10,
                ValorNeto = 1010,
                ClienteId = 1,
            };
            _facturacionAppService.Setup(s => s.GetFacturaById(idFactura)).ReturnsAsync(facturaOutput);
            _logService.Setup(s => s.Log(It.IsAny<string>())).Verifiable();

            //Act
            var result = await _facturacionController.GetById(idFactura);
            var okResul = result as OkObjectResult;
            var output = okResul.Value as FacturaOutputDto;

            //Assert
            _logService.Verify(s => s.Log(It.IsAny<string>()));

            Assert.NotNull(okResul);
            Assert.NotNull(output);
            Assert.Equal(facturaOutput, output);
        }
    }
}
