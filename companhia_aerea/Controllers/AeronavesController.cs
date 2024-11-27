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
    public class AeronavesController : Controller
    {
        private readonly CompanhiaAereaContext _context;

        public AeronavesController(CompanhiaAereaContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aeronaves.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Poltronas,Modelo")] Aeronave aeronave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeronave);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronaves.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }
            return View(aeronave);
        }

   
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Poltronas,Modelo")] Aeronave aeronave)
        {
            if (id != aeronave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeronave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeronaveExists(aeronave.Id))
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
            return View(aeronave);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeronave = await _context.Aeronaves.FindAsync(id);
            if (aeronave != null)
            {
                _context.Aeronaves.Remove(aeronave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeronaveExists(int id)
        {
            return _context.Aeronaves.Any(e => e.Id == id);
        }
    }
}
