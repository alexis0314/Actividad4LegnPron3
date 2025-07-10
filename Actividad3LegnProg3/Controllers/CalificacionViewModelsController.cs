using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Actividad4LegnProg3.Models;

namespace Actividad4LegnProg3.Controllers
{
    public class CalificacionViewModelsController : Controller
    {
        private readonly Actividad4LegnProg3Context _context;

        public CalificacionViewModelsController(Actividad4LegnProg3Context context)
        {
            _context = context;
        }

        // GET: CalificacionViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Calificaciones.ToListAsync());
        }

        // GET: CalificacionViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionViewModel = await _context.Calificaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacionViewModel == null)
            {
                return NotFound();
            }

            return View(calificacionViewModel);
        }

        // GET: CalificacionViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalificacionViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatriculaEstudiante,CodigoMateria,Nota,Periodo")] CalificacionViewModel calificacionViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacionViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calificacionViewModel);
        }

        // GET: CalificacionViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionViewModel = await _context.Calificaciones.FindAsync(id);
            if (calificacionViewModel == null)
            {
                return NotFound();
            }
            return View(calificacionViewModel);
        }

        // POST: CalificacionViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatriculaEstudiante,CodigoMateria,Nota,Periodo")] CalificacionViewModel calificacionViewModel)
        {
            if (id != calificacionViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacionViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionViewModelExists(calificacionViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calificacionViewModel);
        }

        // GET: CalificacionViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionViewModel = await _context.Calificaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacionViewModel == null)
            {
                return NotFound();
            }

            return View(calificacionViewModel);
        }

        // POST: CalificacionViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacionViewModel = await _context.Calificaciones.FindAsync(id);
            if (calificacionViewModel != null)
            {
                _context.Calificaciones.Remove(calificacionViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionViewModelExists(int id)
        {
            return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}
