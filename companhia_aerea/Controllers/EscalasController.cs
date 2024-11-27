 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using companhia_aerea.Models;

namespace companhia_aerea.Controllers
{
    public class EscalasController : Controller
    {
        private readonly CompanhiaAereaContext _context;

        public EscalasController(CompanhiaAereaContext context)
        {
            _context = context;
        }

        // GET: Escalas
        public async Task<IActionResult> Index()
        {
            var companhiaAereaContext = _context.Escalas.Include(e => e.IdAeroportoNavigation).Include(e => e.IdVooNavigation);
            return View(await companhiaAereaContext.ToListAsync());
        }

        // GET: Escalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escalas
                .Include(e => e.IdAeroportoNavigation)
                .Include(e => e.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // GET: Escalas/Create
        public IActionResult Create()
        {
            ViewData["IdAeroporto"] = new SelectList(_context.Aeroportos, "Id", "Id");
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id");
            return View();
        }

        // POST: Escalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdVoo,IdAeroporto,Saida")] Escala escala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAeroporto"] = new SelectList(_context.Aeroportos, "Id", "Id", escala.IdAeroporto);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", escala.IdVoo);
            return View(escala);
        }

        // GET: Escalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escalas.FindAsync(id);
            if (escala == null)
            {
                return NotFound();
            }
            ViewData["IdAeroporto"] = new SelectList(_context.Aeroportos, "Id", "Id", escala.IdAeroporto);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", escala.IdVoo);
            return View(escala);
        }

        // POST: Escalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdVoo,IdAeroporto,Saida")] Escala escala)
        {
            if (id != escala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscalaExists(escala.Id))
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
            ViewData["IdAeroporto"] = new SelectList(_context.Aeroportos, "Id", "Id", escala.IdAeroporto);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", escala.IdVoo);
            return View(escala);
        }

        // GET: Escalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escalas
                .Include(e => e.IdAeroportoNavigation)
                .Include(e => e.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // POST: Escalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escala = await _context.Escalas.FindAsync(id);
            if (escala != null)
            {
                _context.Escalas.Remove(escala);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscalaExists(int id)
        {
            return _context.Escalas.Any(e => e.Id == id);
        }
    }
}
