using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuyaPagos.Application.Dtos.Facturacion;

namespace TuyaPagos.WebApi.Controllers
{
    public class PedidosController : Controller
    {
        public PedidosController()
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaInputDto facturaInput)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
