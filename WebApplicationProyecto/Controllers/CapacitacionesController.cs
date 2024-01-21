using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProyecto.Models;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using WebApplicationProyecto.Services;
using Microsoft.EntityFrameworkCore;


namespace WebApplicationProyecto.Controllers
{
    public class CapacitacionesController : Controller
    {

        // Dependencia para comunicarse con la API.
        private readonly IApiService _apiService;

        public CapacitacionesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: CapacitacionesController  
        public async Task<IActionResult> Index()
        {
            try
            {
                var capacitaciones = await _apiService.getCapacitaciones();
                return View(capacitaciones);
            }
            catch (Exception e)
            {
                return View(new List<Capacitaciones>());
            }
        }

        // GET: MedicoController/Details/5 //ListarDatos
        public async Task<ActionResult> Details(int IdCapacitaciones)
        {
            var capacitaciones = await _apiService.getCapacitaciones(IdCapacitaciones);
            if (capacitaciones != null)
            {
                return View(capacitaciones);
            }
            return RedirectToAction("Index");
        }

        // GET: MedicoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicoController/Create //Crear Nuevo
        [HttpPost]
        public async Task<IActionResult> Create(Capacitaciones capacitaciones)
        {
            var result = await _apiService.addCapacitaciones(capacitaciones);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(capacitaciones);
        }

        // GET: MedicoController/Edit/5
        public async Task<IActionResult> Edit(int IdCapacitaciones)
        {
            var capacitaciones = await _apiService.getCapacitaciones(IdCapacitaciones);
            if (capacitaciones != null)
            {
                return View(capacitaciones);
            }
            return RedirectToAction("Index");
        }

        // POST: MedicoController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Capacitaciones capacitaciones)
        {
            var pAEditar = await _apiService.updateCapacitaciones(capacitaciones.IdCapacitaciones, capacitaciones);
            if (pAEditar != null)
            {
                return RedirectToAction(nameof(Index)); //Nameof se utiliza para obtener el nombre de una variable, tipo o miembro de una clase como una cadena en tiempo de compilación. 
            }
            return View(pAEditar);
        }


        // GET: MedicoController/Delete/5 //Eliminar
        public ActionResult Delete(int IdCapacitaciones)
        {
            var pEliminar = _apiService.deleteCapacitaciones(IdCapacitaciones);
            return RedirectToAction(nameof(Index));

        }
    }
}
