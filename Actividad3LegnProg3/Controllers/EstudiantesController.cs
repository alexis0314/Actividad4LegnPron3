using Actividad4LegnProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;

namespace AcAtividad3LegnProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> Estudiante = new List<EstudianteViewModel>()
    {
        new EstudianteViewModel() { Nombrecompleto = "Alexis", Matricula = "1234", Carrera = "Ingeniería en Software" }
    };

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(Estudiante); 
        }

        [HttpGet]
        public IActionResult Registro()
        {
            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View();
        }

        [HttpPost]
        public IActionResult Registro(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                Estudiante.Add(model);
                TempData["Mensaje"] = "El estudiante se ha registrado exitosamente";
                return RedirectToAction("Registro");
            }

            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View(model);
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            if (id >= 0 && id < Estudiante.Count)
            {
                var estudiante = Estudiante[id];
                ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
                ViewBag.Id = id;
                return View("Editar", estudiante);
            }
            return RedirectToAction("Lista");
        }

        [HttpPost]
        public IActionResult Editar(int id, EstudianteViewModel model)
        {
            if (ModelState.IsValid && id >= 0 && id < Estudiante.Count)
            {
                Estudiante[id] = model;
                TempData["Mensaje"] = "Estudiante actualizado";
                return RedirectToAction("Lista");
            }
            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View("Editar", model);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            if (id >= 0 && id < Estudiante.Count)
            {
                Estudiante.RemoveAt(id);
                TempData["Mensaje"] = "Estudiante eliminado";
            }
            return RedirectToAction("Lista");
        }

    }
}
