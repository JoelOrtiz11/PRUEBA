using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Models;

namespace prueba.Controllers
{
    public class empresasController : Controller
    {
        private readonly trabajosDbContext _context;

        public empresasController(trabajosDbContext context)
        {
            _context = context;
        }

        // GET: empresas
        public async Task<IActionResult> Index()
        {
              return _context.empresa != null ? 
                          View(await _context.empresa.ToListAsync()) :
                          Problem("Entity set 'trabajosDbContext.empresa'  is null.");
        }

        // GET: empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.empresa == null)
            {
                return NotFound();
            }

            var empresa = await _context.empresa
                .FirstOrDefaultAsync(m => m.empresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: empresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empresaID,nombre,correo,telefono")] empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.empresa == null)
            {
                return NotFound();
            }

            var empresa = await _context.empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empresaID,nombre,correo,telefono")] empresa empresa)
        {
            if (id != empresa.empresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!empresaExists(empresa.empresaID))
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
            return View(empresa);
        }

        // GET: empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.empresa == null)
            {
                return NotFound();
            }

            var empresa = await _context.empresa
                .FirstOrDefaultAsync(m => m.empresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.empresa == null)
            {
                return Problem("Entity set 'trabajosDbContext.empresa'  is null.");
            }
            var empresa = await _context.empresa.FindAsync(id);
            if (empresa != null)
            {
                _context.empresa.Remove(empresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool empresaExists(int id)
        {
          return (_context.empresa?.Any(e => e.empresaID == id)).GetValueOrDefault();
        }
    }
}
