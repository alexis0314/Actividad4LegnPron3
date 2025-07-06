using Actividad4LegnProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LegnProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly Actividad4LegnProg3Context _context;

        public EstudiantesController(Actividad4LegnProg3Context context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            var estudiante = new EstudianteViewModel();
            return View(estudiante);

        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View();
        }

        // POST: Estudiantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(model);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El estudiante se ha registrado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View(model);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstudianteViewModel model)
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Estudiantes.Any(e => e.Matricula == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Carrera = new List<string> { "Ingeniería en Software", "Contabilidad", "Derecho" };
            return View(model);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Estudiante eliminado";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
