using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationProyecto.Models;

namespace WebApplicationProyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult PaginaInicio()
        {
            return View();
        }

        public ActionResult Entrada()
        {
            return View();
        }

        public ActionResult Nosotros()
        {
            return View();
        }

        public ActionResult IndexBullying()
        {
            return View();
        }

        public ActionResult Formulario()
        {
            return View();
        }

        public ActionResult Contactanos()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Juegos()
        {
            return View();
        }

        public ActionResult AcosoIndex()
        {
            return View();
        }
        public ActionResult TrastornoIndex()
        {
            return View();
        }

        public ActionResult Preventiva()
        {
            return View();
        }

        public ActionResult Durante()
        {
            return View();
        }

        public ActionResult Despues()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
