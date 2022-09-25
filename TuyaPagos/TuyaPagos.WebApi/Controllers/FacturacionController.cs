using Microsoft.AspNetCore.Mvc;
using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Application.Services.Facturacion;
using TuyaPagos.Infraestructure.Logging;

namespace TuyaPagos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturacionController : Controller
    {
        private readonly IFacturacionAppService _facturacionAppService;
        private readonly ILogService<FacturacionController> _logService;

        public FacturacionController(IFacturacionAppService facturacionAppService, ILogService<FacturacionController> logService)
        {
            _facturacionAppService = facturacionAppService;
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacturaInputDto facturaInput)
        {
            _logService.Log("Creando factura ...");
            await _facturacionAppService.CrearFactura(facturaInput);
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FacturaOutputDto))]
        public async Task<ActionResult> GetById(int id)
        {
            _logService.Log("Consultando factura ...");
            return Ok(await _facturacionAppService.GetFacturaById(id));
        }
    }
}
