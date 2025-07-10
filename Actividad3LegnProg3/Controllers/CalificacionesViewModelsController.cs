using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Actividad4LegnProg3.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Actividad4LegnProg3.Controllers
{
    public class CalificacionesViewModelsController : Controller
    {
        private readonly Actividad4LegnProg3Context _context;

        public CalificacionesViewModelsController(Actividad4LegnProg3Context context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public async Task<IActionResult> Index()
        {
            var calificaciones = _context.Calificaciones
                .Include(c => c.Estudiante)
                .Include(c => c.Materia);
            return View(await calificaciones.ToListAsync());
        }

        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var calificacion = await _context.Calificaciones
                .Include(c => c.Estudiante)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (calificacion == null) return NotFound();

            return View(calificacion);
        }

        // GET: Calificaciones/Create
        public IActionResult Create()
        {
            // Obtener lista de estudiantes filtrando nulos
            var estudiantes = _context.Estudiantes
                .Where(e => e.Matricula != null && e.Nombrecompleto != null)
                .ToList();

            // Si está vacía, se asigna una lista vacía para evitar error
            if (!estudiantes.Any())
            {
                ViewBag.EstudianteId = new List<SelectListItem>(); // Evita el NullReference
            }
            else
            {
                ViewBag.EstudianteId = new SelectList(estudiantes, "Matricula", "Nombre");
            }

            // Repetir lógica para Materias
            var materias = _context.Materias
                .Where(m => m.Codigo != null && m.Nombre != null)
                .ToList();

            if (!materias.Any())
            {
                ViewBag.MateriaId = new List<SelectListItem>();
            }
            else
            {
                ViewBag.MateriaId = new SelectList(materias, "Codigo", "Nombre");
            }

            return View();

        }

        // POST: Calificaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstudianteId,MateriaId,Nota,Periodo")] CalificacionesViewModel calificacion)
        {
            if (ModelState.IsValid)
            {
                var calificacion1 = new CalificacionesViewModel
                {
                    EstudianteId = calificacion.EstudianteId,
                    MateriaId = calificacion.MateriaId,
                    Nota = calificacion.Nota,
                    Periodo = calificacion.Periodo
                };

                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // 👇 Recargar combos si hay error
            ViewBag.EstudianteId = new SelectList(_context.Estudiantes.ToList(), "Matricula", "Nombrecompleto", calificacion.EstudianteId);
            ViewBag.MateriaId = new SelectList(_context.Materias.ToList(), "Codigo", "Nombre", calificacion.MateriaId);

            return View(calificacion);

        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null) return NotFound();

            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Matricula", "Nombre", calificacion.EstudianteId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Codigo", "Nombre", calificacion.MateriaId);
            return View(calificacion);
        }

        // POST: Calificaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstudianteId,MateriaId,Nota,Periodo")] CalificacionesViewModel calificacion)
        {
            if (id != calificacion.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionExists(calificacion.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Matricula", "Nombre", calificacion.EstudianteId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Codigo", "Nombre", calificacion.MateriaId);
            return View(calificacion);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var calificacion = await _context.Calificaciones
                .Include(c => c.Estudiante)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (calificacion == null) return NotFound();

            return View(calificacion);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion != null)
            {
                _context.Calificaciones.Remove(calificacion);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}
