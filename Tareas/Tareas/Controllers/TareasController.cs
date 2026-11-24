using Microsoft.AspNetCore.Mvc;
using Tareas.Models;
using Tareas.Services;

namespace Tareas.Controllers
    {

    public class TareasController : Controller
        {

        private readonly ITareaServicio _tareaServicio;

        public TareasController(ITareaServicio tareaServicio)
            {
                _tareaServicio = tareaServicio;
            }

        public IActionResult Index()
            {
            var tareas = _tareaServicio.ObtenerTodas();
            return View(tareas);
            }

        [HttpGet]
        public IActionResult Crear()
            {
            return View(new Tarea());
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Tarea tarea)
        {
            if (ModelState.IsValid == false)
            {
                return View(tarea);
            }

            _tareaServicio.Agregar(tarea);
            TempData["Mensaje"] = "Tarea creada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AlternarCompletada(int id)
        {
            var actualizada = _tareaServicio.AlternarCompletada(id);

            if (actualizada == false)
            {
                TempData["Error"] = "No se encontró la tarea indicada.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Mensaje"] = "Estado de la tarea actualizado.";
            return RedirectToAction(nameof(Index));
        }
        }
    }
