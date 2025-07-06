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
    public class CalificacionesViewModelsController : Controller
    {
        private readonly Actividad4LegnProg3Context _context;

        public CalificacionesViewModelsController(Actividad4LegnProg3Context context)
        {
            _context = context;
        }

        // GET: CalificacionesViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Calificaciones.ToListAsync());
        }

        // GET: CalificacionesViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionesViewModel = await _context.Calificaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacionesViewModel == null)
            {
                return NotFound();
            }

            return View(calificacionesViewModel);
        }

        // GET: CalificacionesViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalificacionesViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatriculaEstudiantes,CodigoMateria,Nota,Periodo")] CalificacionesViewModel calificacionesViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacionesViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calificacionesViewModel);
        }

        // GET: CalificacionesViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionesViewModel = await _context.Calificaciones.FindAsync(id);
            if (calificacionesViewModel == null)
            {
                return NotFound();
            }
            return View(calificacionesViewModel);
        }

        // POST: CalificacionesViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatriculaEstudiantes,CodigoMateria,Nota,Periodo")] CalificacionesViewModel calificacionesViewModel)
        {
            if (id != calificacionesViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacionesViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionesViewModelExists(calificacionesViewModel.Id))
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
            return View(calificacionesViewModel);
        }

        // GET: CalificacionesViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacionesViewModel = await _context.Calificaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacionesViewModel == null)
            {
                return NotFound();
            }

            return View(calificacionesViewModel);
        }

        // POST: CalificacionesViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacionesViewModel = await _context.Calificaciones.FindAsync(id);
            if (calificacionesViewModel != null)
            {
                _context.Calificaciones.Remove(calificacionesViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionesViewModelExists(int id)
        {
            return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}
