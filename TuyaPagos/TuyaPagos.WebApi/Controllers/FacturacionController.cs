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
            return Ok();
        }
    }
}
