using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProyecto.Models;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using WebApplicationProyecto.Services;


namespace WebApplicationProyecto.Controllers
{
    public class AccesoController : Controller
    {

        // Dependencia para comunicarse con la API.
        private readonly IApiService _apiService;

        // Constructor que inyecta el servicio de la API.
        public AccesoController(IApiService apiService)
        {
            _apiService = apiService;
        }



        // GET: CapacitacionesController  
        public async Task<IActionResult> Index()
        {
            try
            {
                var usuarios = await _apiService.getUsuario();
                return View(usuarios);
            }
            catch (Exception e)
            {
                return View(new List<Capacitaciones>());
            }
        }

        // GET: CapacitacionesController/Details/5 //ListarDatos
        public async Task<ActionResult> Details(int IdUsuario)
        {
            var usuarios = await _apiService.getCapacitaciones(IdUsuario);
            if (usuarios != null)
            {
                return View(usuarios);
            }
            return RedirectToAction("Index");
        }

        // GET: CapacitacionesController/Create 
        public ActionResult Create()
        {
            return View();
        }

        // POST: CapacitacionesController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Create(Usuarios usuarios)
        {
            var result = await _apiService.addUsuario(usuarios);
            if (result)
            {
                return RedirectToAction(nameof(Index));//Para los errores sirve el namaof (muestra los errores)
            }
            return View(usuarios);
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int IdUsuario)
        {
            var usuarios = await _apiService.getUsuario(IdUsuario);
            if (usuarios != null)
            {
                return View(usuarios);
            }
            return RedirectToAction("Index");
        }

        // POST: UsuarioController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Usuarios usuarios)
        {
            var pAEditar = await _apiService.updateUsuario(usuarios.IdUsuario, usuarios);
            if (pAEditar != null)
            {
                return RedirectToAction(nameof(Index)); //Nameof se utiliza para obtener el nombre de una variable, tipo o miembro de una clase como una cadena en tiempo de compilación. 
            }
            return View(pAEditar);
        }


        // GET: UsuarioController/Delete/5 //Eliminar
        public ActionResult Delete(int IdUsuario)
        {
            var pEliminar = _apiService.deleteUsuario(IdUsuario);
            return RedirectToAction(nameof(Index));

        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Nosotros()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Usuarios inicioSesion)
        {
            try
            {
                var result = await _apiService.IniciarSesion(inicioSesion);

                if (result)
                {
                    var esAdmin = await _apiService.DeterminarRol(inicioSesion);

                    if (esAdmin)
                    {
                        // Redirige al usuario con rol de Admin a una página específica
                        return RedirectToAction("Index", "Capacitaciones");
                    }
                    else
                    {
                        // Redirige al usuario a la página de inicio por defecto
                        return RedirectToAction("PaginaInicio", "Home");
                    }
                }
                else
                {
                    // Si el inicio de sesión falla, muestra un mensaje de error en la vista
                    TempData["ErrorMessage"] = "Credenciales inválidas. Intente nuevamente.";
                    return View(inicioSesion);
                }
            }
            catch (Exception e)
            {
                // Maneja la excepción según sea necesario
                TempData["ErrorMessage"] = "Error en el servidor. Intente nuevamente más tarde.";
                return View(inicioSesion);
            }
        }






    }
}
