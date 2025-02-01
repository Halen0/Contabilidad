using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contabilidad.Models;

namespace Contabilidad.Controllers
{
    public class PasivosController : Controller
    {
        private readonly ContabilidadContext _context;

        public PasivosController(ContabilidadContext context)
        {
            _context = context;
        }

        // GET: Pasivoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pasivos.ToListAsync());
        }

        // GET: Pasivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasivo = await _context.Pasivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasivo == null)
            {
                return NotFound();
            }

            return View(pasivo);
        }

        // GET: Pasivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pasivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Fecha,Monto")] Pasivo pasivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasivo);
        }

        // GET: Pasivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasivo = await _context.Pasivos.FindAsync(id);
            if (pasivo == null)
            {
                return NotFound();
            }
            return View(pasivo);
        }

        // POST: Pasivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Fecha,Monto")] Pasivo pasivo)
        {
            if (id != pasivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasivoExists(pasivo.Id))
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
            return View(pasivo);
        }

        // GET: Pasivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasivo = await _context.Pasivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasivo == null)
            {
                return NotFound();
            }

            return View(pasivo);
        }

        // POST: Pasivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasivo = await _context.Pasivos.FindAsync(id);
            if (pasivo != null)
            {
                _context.Pasivos.Remove(pasivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasivoExists(int id)
        {
            return _context.Pasivos.Any(e => e.Id == id);
        }
    }
}
