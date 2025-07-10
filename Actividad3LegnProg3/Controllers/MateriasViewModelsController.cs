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
    public class MateriasViewModelsController : Controller
    {
        private readonly Actividad4LegnProg3Context _context;

        public MateriasViewModelsController(Actividad4LegnProg3Context context)
        {
            _context = context;
        }

        // GET: MateriasViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materias.ToListAsync());
        }

        // GET: MateriasViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiasViewModel = await _context.Materias
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (materiasViewModel == null)
            {
                return NotFound();
            }

            return View(materiasViewModel);
        }

        // GET: MateriasViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriasViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nombre,Creditos,Carrera")] MateriasViewModel materiasViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiasViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiasViewModel);
        }

        // GET: MateriasViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiasViewModel = await _context.Materias.FindAsync(id);
            if (materiasViewModel == null)
            {
                return NotFound();
            }
            return View(materiasViewModel);
        }

        // POST: MateriasViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nombre,Creditos,Carrera")] MateriasViewModel materiasViewModel)
        {
            if (id != materiasViewModel.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiasViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriasViewModelExists(materiasViewModel.Codigo))
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
            return View(materiasViewModel);
        }

        // GET: MateriasViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiasViewModel = await _context.Materias
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (materiasViewModel == null)
            {
                return NotFound();
            }

            return View(materiasViewModel);
        }

        // POST: MateriasViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiasViewModel = await _context.Materias.FindAsync(id);
            if (materiasViewModel != null)
            {
                _context.Materias.Remove(materiasViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriasViewModelExists(int id)
        {
            return _context.Materias.Any(e => e.Codigo == id);
        }
    }
}
