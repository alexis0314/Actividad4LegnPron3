using Actividad4LegnProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcAtividad3LegnProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly Actividad4LegnProg3Context _context;

        public EstudiantesController(Actividad4LegnProg3Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            var listaEstudiantes = _context.Estudiantes.ToList();
            return View(listaEstudiantes);
        }



            [HttpPost]
            public IActionResult Registro(EstudianteViewModel model)
            {
                if (ModelState.IsValid)
                {
                    _context.Estudiantes.Add(model);
                    var filasAfectadas = _context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        TempData["Mensaje"] = "Estudiante registrado correctamente.";
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
                return View(model);
            }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            if (ModelState.IsValid)
            {
                var estudiante = _context.Estudiantes.Skip(id).FirstOrDefault();

                ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
                ViewBag.Id = id;
                return View("Editar", estudiante);
            }
            return RedirectToAction("Lista");

        }

        [HttpPost]
        public IActionResult Editar(String id, EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estudiante =

               
                TempData["Mensaje"] = "Estudiante actualizado";
                return RedirectToAction("Lista");

                _context.SaveChanges();
            }
            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View("Editar", model);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            if (ModelState.IsValid)
            {
               
                TempData["Mensaje"] = "Estudiante eliminado";
            }
            return RedirectToAction("Lista");
        }

    }
}
