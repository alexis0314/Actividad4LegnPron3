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
        public async Task<IActionResult> Editar(string id)
        {
            if (id == null)
                return NotFound();

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View(estudiante);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(string id, EstudianteViewModel model)
        {
            if (id != model.Matricula)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Estudiante actualizado";
                    return RedirectToAction("Lista");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Estudiantes.Any(e => e.Matricula == id))
                        return NotFound();
                    else
                        throw;
                }
                
            }

            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            return View(estudiante);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(string id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Estudiante eliminado";
            }

            return RedirectToAction("Lista");
        }

    }
}
