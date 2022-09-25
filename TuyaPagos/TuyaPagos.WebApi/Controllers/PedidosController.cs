using Microsoft.AspNetCore.Mvc;
using TuyaPagos.Application.Dtos.Pedidos;
using TuyaPagos.Application.Services.Pedidos;
using TuyaPagos.Infraestructure.Logging;

namespace TuyaPagos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidosAppService _pedidosAppService;
        private readonly ILogService<PedidosController> _logService;

        public PedidosController(IPedidosAppService pedidosAppService, ILogService<PedidosController> logService)
        {
            _pedidosAppService = pedidosAppService;
            _logService = logService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PedidoInputDto pedidoInput)
        {
            _logService.Log("Creando pedido ...");
            await _pedidosAppService.CreatePedido(pedidoInput);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoOutputDto))]
        public async Task<ActionResult> GetById(int id)
        {
            _logService.Log("Consultando pedido ...");
            return Ok(await _pedidosAppService.GetPedidoById(id));
        }
    }
}
