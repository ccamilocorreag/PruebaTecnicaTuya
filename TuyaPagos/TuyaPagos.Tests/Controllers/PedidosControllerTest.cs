using Microsoft.AspNetCore.Mvc;
using Moq;
using TuyaPagos.Application.Dtos.Pedidos;
using TuyaPagos.Application.Services.Pedidos;
using TuyaPagos.Infraestructure.Logging;
using TuyaPagos.WebApi.Controllers;

namespace TuyaPagos.Tests.Controllers
{
    public class PedidosControllerTest
    {
        private readonly Mock<IPedidosAppService> _PedidosAppService;
        private readonly Mock<ILogService<PedidosController>> _logService;
        private readonly PedidosController _PedidosController;

        public PedidosControllerTest()
        {
            _PedidosAppService = new Mock<IPedidosAppService>();
            _logService = new Mock<ILogService<PedidosController>>();
            _PedidosController = new PedidosController(_PedidosAppService.Object, _logService.Object);
        }

        [Fact]
        public async Task WhenCreatePedido_ShouldNoContentResult()
        {
            //Arrange 
            var PedidoInput = new PedidoInputDto()
            {
                FacturaId = 1,
                Ciudad = "Medellin",
                Departamento = "Departamento",
                Direccion = "Calle 3"
            };

            _PedidosAppService.Setup(s => s.CreatePedido(PedidoInput)).Verifiable();
            _logService.Setup(s => s.Log(It.IsAny<string>())).Verifiable();

            //Act
            var result = await _PedidosController.Create(PedidoInput);
            var noContentResult = result as NoContentResult;

            //Assert
            _PedidosAppService.Verify(s => s.CreatePedido(PedidoInput));
            _logService.Verify(s => s.Log(It.IsAny<string>()));

            Assert.Equal(204, noContentResult.StatusCode);

        }

        [Fact]
        public async Task WhenGetByIdPedido_ShouldReturnPedido()
        {
            //Arrange 
            var idPedido = 1;
            var PedidoOutput = new PedidoOutputDto()
            {
                Id = 1,
                Fecha = DateTime.Now,
                Ciudad = "Medellin",
                Departamento = "Departamento",
                Direccion = "Calle 3",
                FacturaId = 1
            };
            _PedidosAppService.Setup(s => s.GetPedidoById(idPedido)).ReturnsAsync(PedidoOutput);
            _logService.Setup(s => s.Log(It.IsAny<string>())).Verifiable();

            //Act
            var result = await _PedidosController.GetById(idPedido);
            var okResul = result as OkObjectResult;
            var output = okResul.Value as PedidoOutputDto;

            //Assert
            _logService.Verify(s => s.Log(It.IsAny<string>()));

            Assert.NotNull(okResul);
            Assert.NotNull(output);
            Assert.Equal(PedidoOutput, output);
        }
    }
}
