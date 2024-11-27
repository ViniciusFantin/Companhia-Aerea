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
    public class AeroportosController : Controller
    {
        private readonly CompanhiaAereaContext _context;

        public AeroportosController(CompanhiaAereaContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aeroportos.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroporto = await _context.Aeroportos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            return View(aeroporto);
        }

        public IActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Rua,Numero,Bairro,Cidade,Estado,Pais")] Aeroporto aeroporto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeroporto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeroporto);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroporto = await _context.Aeroportos.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }
            return View(aeroporto);
        }

        
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Rua,Numero,Bairro,Cidade,Estado,Pais")] Aeroporto aeroporto)
        {
            if (id != aeroporto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeroporto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeroportoExists(aeroporto.Id))
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
            return View(aeroporto);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroporto = await _context.Aeroportos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            return View(aeroporto);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeroporto = await _context.Aeroportos.FindAsync(id);
            if (aeroporto != null)
            {
                _context.Aeroportos.Remove(aeroporto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeroportoExists(int id)
        {
            return _context.Aeroportos.Any(e => e.Id == id);
        }
    }
}
