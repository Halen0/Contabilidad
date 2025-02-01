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
    public class AhorrosController : Controller
    {
        private readonly ContabilidadContext _context;

        public AhorrosController(ContabilidadContext context)
        {
            _context = context;
        }

        // GET: Ahorros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ahorros.ToListAsync());
        }

        // GET: Ahorros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ahorro = await _context.Ahorros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ahorro == null)
            {
                return NotFound();
            }

            return View(ahorro);
        }

        // GET: Ahorros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ahorros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Fecha,Monto")] Ahorro ahorro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ahorro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ahorro);
        }

        // GET: Ahorros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ahorro = await _context.Ahorros.FindAsync(id);
            if (ahorro == null)
            {
                return NotFound();
            }
            return View(ahorro);
        }

        // POST: Ahorros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Fecha,Monto")] Ahorro ahorro)
        {
            if (id != ahorro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ahorro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AhorroExists(ahorro.Id))
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
            return View(ahorro);
        }

        // GET: Ahorros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ahorro = await _context.Ahorros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ahorro == null)
            {
                return NotFound();
            }

            return View(ahorro);
        }

        // POST: Ahorros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ahorro = await _context.Ahorros.FindAsync(id);
            if (ahorro != null)
            {
                _context.Ahorros.Remove(ahorro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AhorroExists(int id)
        {
            return _context.Ahorros.Any(e => e.Id == id);
        }
    }
}
