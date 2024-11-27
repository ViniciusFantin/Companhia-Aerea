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
    public class PassageirosController : Controller
    {
        private readonly CompanhiaAereaContext _context;

        public PassageirosController(CompanhiaAereaContext context)
        {
            _context = context;
        }

        // GET: Passageiroes
        public async Task<IActionResult> Index()
        {
            var companhiaAereaContext = _context.Passageiros.Include(p => p.IdClienteNavigation).Include(p => p.IdPoltronaNavigation).Include(p => p.IdVooNavigation);
            return View(await companhiaAereaContext.ToListAsync());
        }

        // GET: Passageiroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdPoltronaNavigation)
                .Include(p => p.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // GET: Passageiroes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["IdPoltrona"] = new SelectList(_context.Poltronas, "Id", "Id");
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id");
            return View();
        }

        // POST: Passageiroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,IdVoo,Passagem,IdPoltrona")] Passageiro passageiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passageiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", passageiro.IdCliente);
            ViewData["IdPoltrona"] = new SelectList(_context.Poltronas, "Id", "Id", passageiro.IdPoltrona);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", passageiro.IdVoo);
            return View(passageiro);
        }

        // GET: Passageiroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros.FindAsync(id);
            if (passageiro == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", passageiro.IdCliente);
            ViewData["IdPoltrona"] = new SelectList(_context.Poltronas, "Id", "Id", passageiro.IdPoltrona);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", passageiro.IdVoo);
            return View(passageiro);
        }

        // POST: Passageiroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,IdVoo,Passagem,IdPoltrona")] Passageiro passageiro)
        {
            if (id != passageiro.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passageiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassageiroExists(passageiro.IdCliente))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", passageiro.IdCliente);
            ViewData["IdPoltrona"] = new SelectList(_context.Poltronas, "Id", "Id", passageiro.IdPoltrona);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "Id", "Id", passageiro.IdVoo);
            return View(passageiro);
        }

        // GET: Passageiroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdPoltronaNavigation)
                .Include(p => p.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // POST: Passageiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passageiro = await _context.Passageiros.FindAsync(id);
            if (passageiro != null)
            {
                _context.Passageiros.Remove(passageiro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassageiroExists(int id)
        {
            return _context.Passageiros.Any(e => e.IdCliente == id);
        }
    }
}
